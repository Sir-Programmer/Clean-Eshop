using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.ProductAgg;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Products.DTOs;

namespace Shop.Query.Products.Services;

public class ProductQueryService(ShopContext context) : IProductQueryService
{
    public Task<ProductDto?> GetByIdAsync(Guid productId, CancellationToken cancellationToken = default)
        => GetProductAsync(p => p.Id == productId, cancellationToken);

    public Task<ProductDto?> GetBySlugAsync(string slug, CancellationToken cancellationToken = default)
        => GetProductAsync(p => p.Slug == slug, cancellationToken);

    private async Task<ProductDto?> GetProductAsync(Expression<Func<Product, bool>> predicate, CancellationToken cancellationToken)
    {
        var product = await context.Products
            .Include(p => p.SubCategories)
            .SingleOrDefaultAsync(predicate, cancellationToken);

        if (product is null) return null;

        var categoryIds = new List<Guid> { product.MainCategoryId };
        categoryIds.AddRange(product.SubCategories.Select(s => s.CategoryId));

        var productCategoryItems = await context.Categories
            .Where(c => categoryIds.Contains(c.Id))
            .Select(c => c.MapCategory())
            .ToListAsync(cancellationToken);

        return product.MapOrNull(productCategoryItems!);
    }
}
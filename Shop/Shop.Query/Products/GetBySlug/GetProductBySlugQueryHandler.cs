using Common.Query;
using Shop.Query.Products.DTOs;
using Shop.Query.Products.Services;

namespace Shop.Query.Products.GetBySlug;

public class GetProductBySlugQueryHandler(IProductQueryService productQueryService) : IQueryHandler<GetProductBySlugQuery, ProductDto?>
{
    public async Task<ProductDto?> Handle(GetProductBySlugQuery request, CancellationToken cancellationToken) =>
        await productQueryService.GetBySlugAsync(request.Slug, cancellationToken: cancellationToken);
}
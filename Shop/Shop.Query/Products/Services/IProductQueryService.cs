using Shop.Query.Products.DTOs;

namespace Shop.Query.Products.Services;

public interface IProductQueryService
{
    Task<ProductDto?> GetByIdAsync(Guid productId, CancellationToken cancellationToken = default);
    Task<ProductDto?> GetBySlugAsync(string slug, CancellationToken cancellationToken = default);
}
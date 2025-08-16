using Common.Query;
using Shop.Query.Products.DTOs;
using Shop.Query.Products.Services;

namespace Shop.Query.Products.GetById;

public class GetProductByIdQueryHandler(IProductQueryService productQueryService) : IQueryHandler<GetProductByIdQuery, ProductDto?>
{
    public async Task<ProductDto?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken) =>
        await productQueryService.GetByIdAsync(request.ProductId, cancellationToken);
}
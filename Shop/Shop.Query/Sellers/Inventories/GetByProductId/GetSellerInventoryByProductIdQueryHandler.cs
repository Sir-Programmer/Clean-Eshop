using Common.Query;
using Dapper;
using Shop.Infrastructure.Persistent.Dapper;
using Shop.Query.Sellers.DTOs;

namespace Shop.Query.Sellers.Inventories.GetByProductId;

public class GetSellerInventoryByProductIdQueryHandler(DapperContext dapperContext) : IQueryHandler<GetSellerInventoryByProductIdQuery, InventoryDto?>
{
    public async Task<InventoryDto?> Handle(GetSellerInventoryByProductIdQuery request, CancellationToken cancellationToken)
    {
        using var connection = dapperContext.CreateConnection();
        const string sql = $"""
                            SELECT Top(1) p.Id as ProductId, p.Title as ProductTitle, p.ImageName as ProductImage, i.Count, i.Price, s.Id as SellerId, s.ShopName as ShopName, i.DiscountPercentage, i.IsActive 
                                                 FROM {DapperContext.Inventories} i 
                                                 INNER JOIN {DapperContext.Sellers} s ON s.Id = i.SellerId
                                                 INNER JOIN {DapperContext.Products} p ON p.Id = i.ProductId
                                                 WHERE i.ProductId = @ProductId
                            """;
        return await connection.QueryFirstOrDefaultAsync(sql, new { request.ProductId });
    }
}
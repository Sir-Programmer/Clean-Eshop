using Common.Query;
using Dapper;
using Shop.Infrastructure.Persistent.Dapper;
using Shop.Query.Sellers.DTOs;

namespace Shop.Query.Sellers.Inventories.GetById;

public class GetSellerInventoryByIdQueryHandler(DapperContext dapperContext) : IQueryHandler<GetSellerInventoryByIdQuery, InventoryDto?>
{
    public async Task<InventoryDto?> Handle(GetSellerInventoryByIdQuery request, CancellationToken cancellationToken)
    {
        using var connection = dapperContext.CreateConnection();
        const string sql = $"""
                            SELECT Top(1) p.Id AS ProductId, p.Title AS ProductTitle, p.ImageName AS ProductImage, i.Count, i.Price, s.Id AS SellerId, s.ShopName AS ShopName, i.DiscountPercentage, i.IsActive 
                                                 FROM {DapperContext.Inventories} i 
                                                 INNER JOIN {DapperContext.Sellers} s ON s.Id = i.SellerId
                                                 INNER JOIN {DapperContext.Products} p ON p.Id = i.ProductId
                                                 WHERE i.Id = @inventoryId
                            """;
 
        return await connection.QueryFirstOrDefaultAsync<InventoryDto>(sql, new { request.InventoryId });
    }
}
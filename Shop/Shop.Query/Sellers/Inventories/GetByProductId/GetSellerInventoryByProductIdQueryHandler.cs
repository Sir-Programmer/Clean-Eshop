using Common.Query;
using Dapper;
using Shop.Infrastructure.Persistent.Dapper;
using Shop.Query.Sellers.DTOs;

namespace Shop.Query.Sellers.Inventories.GetByProductId;

public class GetSellerInventoryByProductIdQueryHandler(DapperContext dapperContext) : IQueryHandler<GetSellerInventoryByProductIdQuery, List<InventoryDto>>
{
    public async Task<List<InventoryDto>> Handle(GetSellerInventoryByProductIdQuery request, CancellationToken cancellationToken)
    {
        using var connection = dapperContext.CreateConnection();
        const string sql = $"""
                            SELECT p.Id AS ProductId, p.Title AS ProductTitle, p.ImageName AS ProductImage, i.Count, i.Price, s.Id AS SellerId, s.ShopName AS ShopName, i.DiscountPercentage, i.IsActive 
                                                 FROM {DapperContext.Inventories} i 
                                                 INNER JOIN {DapperContext.Sellers} s ON s.Id = i.SellerId
                                                 INNER JOIN {DapperContext.Products} p ON p.Id = i.ProductId
                                                 WHERE i.ProductId = @ProductId
                            """;
        var result = await connection.QueryAsync<InventoryDto>(sql, new { request.ProductId });
        return result.ToList();
    }
}
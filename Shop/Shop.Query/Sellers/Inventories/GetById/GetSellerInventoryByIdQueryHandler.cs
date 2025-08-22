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
        var sql =
            @$"SELECT Top(1) p.Id as ProductId, p.Title as ProductTitle, p.ImageName as ProductImage, i.Count, i.Price, s.Id as SellerId, s.ShopName as ShopName, i.DiscountPercentage, i.IsActive 
                     FROM {DapperContext.Inventories} i 
                     inner join {DapperContext.Sellers} s on s.Id = i.SellerId
                     inner join {DapperContext.Products} p on p.Id = i.ProductId
                     WHERE i.Id = @inventoryId";
 
        return await connection.QueryFirstOrDefaultAsync<InventoryDto>(sql, new { request.InventoryId });
    }
}
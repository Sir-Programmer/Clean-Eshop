using Dapper;
using Shop.Domain.SellerAgg;
using Shop.Domain.SellerAgg.Repository;
using Shop.Infrastructure._Utilities;
using Shop.Infrastructure.Persistent.Dapper;

namespace Shop.Infrastructure.Persistent.Ef.SellerAgg;

public class SellerRepository(ShopContext context, DapperContext dapperContext) : BaseRepository<Seller>(context), ISellerRepository
{
    public async Task<InventoryResult?> GetInventoryById(Guid inventoryId)
    {
        using var connection = dapperContext.CreateConnection;
        var sql = $"SELECT * FROM {DapperContext.Inventories} WHERE id = @inventoryId";
        return await connection.QueryFirstOrDefaultAsync<InventoryResult>(sql, new { inventoryId });
    }
}
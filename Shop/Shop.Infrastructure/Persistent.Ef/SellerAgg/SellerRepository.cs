using Shop.Domain.SellerAgg;
using Shop.Domain.SellerAgg.Repository;
using Shop.Infrastructure._Utilities;

namespace Shop.Infrastructure.Persistent.Ef.SellerAgg;

public class SellerRepository(ShopContext context) : BaseRepository<Seller>(context), ISellerRepository
{
    public Task<InventoryResult?> GetInventoryById(Guid inventoryId)
    {
        //TODO : Use DAPPER
        throw new NotImplementedException();
    }
}
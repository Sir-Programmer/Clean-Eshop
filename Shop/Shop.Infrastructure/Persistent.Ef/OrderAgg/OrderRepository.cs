using Microsoft.EntityFrameworkCore;
using Shop.Domain.OrderAgg;
using Shop.Domain.OrderAgg.Enums;
using Shop.Domain.OrderAgg.Repository;
using Shop.Infrastructure._Utilities;

namespace Shop.Infrastructure.Persistent.Ef.OrderAgg;

public class OrderRepository(ShopContext context) : BaseRepository<Order>(context), IOrderRepository
{
    public async Task<Order?> GetCurrentUserOrder(Guid userId)
    {
        return await Context.Orders.AsTracking().FirstOrDefaultAsync(o => o.UserId == userId && o.Status == OrderStatus.Created);
    }
}
using Microsoft.EntityFrameworkCore;
using Shop.Domain.CouponAgg;
using Shop.Domain.CouponAgg.Repository;
using Shop.Infrastructure._Utilities;

namespace Shop.Infrastructure.Persistent.Ef.CouponAgg;

public class CouponRepository(ShopContext context) : BaseRepository<Coupon>(context), ICouponRepository
{
    public void Delete(Coupon coupon)
    {
        Context.Remove(coupon);
    }

    public async Task<Coupon?> GetByCodeTrackingAsync(string code)
    {
        return await Context.Coupons.AsTracking().FirstOrDefaultAsync(c => c.Code == code);
    }
}
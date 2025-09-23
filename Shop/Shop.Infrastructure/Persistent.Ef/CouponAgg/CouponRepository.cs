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
}
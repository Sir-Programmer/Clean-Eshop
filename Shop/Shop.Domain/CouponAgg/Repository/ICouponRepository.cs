using Common.Domain.Repository;

namespace Shop.Domain.CouponAgg.Repository;

public interface ICouponRepository : IBaseRepository<Coupon>
{
    void Delete(Coupon coupon);
    Task<Coupon?> GetByCodeTrackingAsync(string code);
}
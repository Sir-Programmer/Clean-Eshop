using Shop.Domain.CouponAgg;
using Shop.Domain.CouponAgg.Repository;

namespace Shop.Application.Coupons;

public class CouponDomainService(ICouponRepository couponRepository) : ICouponDomainService
{
    public bool IsCodeExist(string code)
    {
        return couponRepository.Exists(c => c.Code == code);
    }
}
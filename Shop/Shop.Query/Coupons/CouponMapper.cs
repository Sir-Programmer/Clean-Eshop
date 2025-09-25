using Shop.Domain.CouponAgg;
using Shop.Query.Coupons.DTOs;

namespace Shop.Query.Coupons;

public static class CouponMapper
{
    public static CouponDto? MapOrNull(this Coupon? coupon)
    {
        return coupon?.Map();
    }

    public static CouponDto Map(this Coupon coupon)
    {
        return new CouponDto()
        {
            Id = coupon.Id,
            Code = coupon.Code,
            DiscountType = coupon.DiscountType,
            DiscountAmount = coupon.DiscountAmount,
            CreationTime = coupon.CreationTime,
            ExpirationDate = coupon.ExpirationDate,
            UsageLimit = coupon.UsageLimit,
            UsedCount = coupon.UsedCount
        };
    }
}
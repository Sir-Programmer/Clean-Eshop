using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Coupons.DTOs;

namespace Shop.Query.Coupons.GetById;

public class GetCouponByIdQueryHandler(ShopContext context) : IQueryHandler<GetCouponByIdQuery, CouponDto?>
{
    public async Task<CouponDto?> Handle(GetCouponByIdQuery request, CancellationToken cancellationToken)
    {
        var coupon = await context.Coupons.FirstOrDefaultAsync(c => c.Id == request.CouponId, cancellationToken);
        return coupon.MapOrNull();
    }
}
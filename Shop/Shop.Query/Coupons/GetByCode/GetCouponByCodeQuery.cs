using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Coupons.DTOs;

namespace Shop.Query.Coupons.GetByCode;

public record GetCouponByCodeQuery(string CouponCode) : IQuery<CouponDto?>;

public class GetCouponByCodeQueryHandler(ShopContext context) : IQueryHandler<GetCouponByCodeQuery, CouponDto?>
{
    public async Task<CouponDto?> Handle(GetCouponByCodeQuery request, CancellationToken cancellationToken)
    {
        var coupon = await context.Coupons.FirstOrDefaultAsync(c => c.Code == request.CouponCode, cancellationToken: cancellationToken);
        return coupon.MapOrNull();
    }
}
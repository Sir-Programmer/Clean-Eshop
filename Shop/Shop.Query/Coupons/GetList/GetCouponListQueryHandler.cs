using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Coupons.DTOs;

namespace Shop.Query.Coupons.GetList;

public class GetCouponListQueryHandler(ShopContext context) : IQueryHandler<GetCouponListQuery, List<CouponDto>>
{
    public async Task<List<CouponDto>> Handle(GetCouponListQuery request, CancellationToken cancellationToken)
    {
        return await context.Coupons.Select(c => c.Map()).ToListAsync(cancellationToken);
    }
}
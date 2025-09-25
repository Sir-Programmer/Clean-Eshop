using Common.Query;
using Shop.Query.Coupons.DTOs;

namespace Shop.Query.Coupons.GetList;

public record GetCouponListQuery : IQuery<List<CouponDto>>;
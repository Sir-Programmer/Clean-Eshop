using Common.Query;
using Shop.Query.Coupons.DTOs;

namespace Shop.Query.Coupons.GetById;

public record GetCouponByIdQuery(Guid CouponId) : IQuery<CouponDto?>;
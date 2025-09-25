using Common.Query;
using Shop.Query.Coupons.DTOs;

namespace Shop.Query.Coupons.GetByCode;

public record GetCouponByCodeQuery(string CouponCode) : IQuery<CouponDto?>;
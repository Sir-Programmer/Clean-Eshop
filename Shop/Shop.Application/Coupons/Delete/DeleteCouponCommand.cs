using Common.Application;

namespace Shop.Application.Coupons.Delete;

public record DeleteCouponCommand(Guid CouponId) : IBaseCommand;
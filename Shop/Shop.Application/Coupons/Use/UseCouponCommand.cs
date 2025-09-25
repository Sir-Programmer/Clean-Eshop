using Common.Application;

namespace Shop.Application.Coupons.Use;

public record UseCouponCommand(Guid CouponId) : IBaseCommand;
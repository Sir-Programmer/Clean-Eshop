using Common.Application;
using Shop.Domain._SharedKernel.Enums;

namespace Shop.Application.Coupons.Edit;

public record EditCouponCommand(Guid CouponId, string Code, DiscountType DiscountType, int DiscountAmount, DateTime ExpirationDate, int UsageLimit) : IBaseCommand;
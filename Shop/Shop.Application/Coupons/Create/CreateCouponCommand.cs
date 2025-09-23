using Common.Application;
using Shop.Domain._SharedKernel.Enums;

namespace Shop.Application.Coupons.Create;

public record CreateCouponCommand(string Code, DiscountType DiscountType, int DiscountAmount, DateTime ExpirationDate, int UsageLimit) : IBaseCommand;
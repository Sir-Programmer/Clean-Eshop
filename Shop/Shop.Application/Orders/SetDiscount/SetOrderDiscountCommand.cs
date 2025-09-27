using Common.Application;
using Shop.Domain._SharedKernel.Enums;

namespace Shop.Application.Orders.SetDiscount;

public record SetOrderDiscountCommand(Guid OrderId, string CouponCode) : IBaseCommand;
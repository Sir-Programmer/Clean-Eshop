using Common.Application;
using Shop.Domain._SharedKernel.Enums;

namespace Shop.Application.Orders.SetDiscount;

public record SetOrderDiscountCommand(Guid OrderId, DiscountType DiscountType, int DiscountAmount) : IBaseCommand;
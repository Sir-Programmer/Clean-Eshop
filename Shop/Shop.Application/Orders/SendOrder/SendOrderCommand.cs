using Common.Application;

namespace Shop.Application.Orders.SendOrder;

public record SendOrderCommand(Guid OrderId) : IBaseCommand;
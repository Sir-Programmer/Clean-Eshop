using Common.Application;

namespace Shop.Application.Orders.Finally;

public record FinallyOrderCommand(Guid OrderId) : IBaseCommand;
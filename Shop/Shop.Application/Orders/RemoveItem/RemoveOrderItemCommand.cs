using Common.Application;

namespace Shop.Application.Orders.RemoveItem;

public record RemoveOrderItemCommand(Guid UserId, Guid ItemId) : IBaseCommand;
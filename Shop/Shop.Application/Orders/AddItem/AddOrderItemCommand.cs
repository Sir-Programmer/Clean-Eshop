using Common.Application;

namespace Shop.Application.Orders.AddItem;

public record AddOrderItemCommand(Guid UserId, Guid InventoryId, int Count) : IBaseCommand;
using Common.Application;

namespace Shop.Application.Orders.DecreaseItemCount;

public record DecreaseOrderItemCountCommand(Guid UserId, Guid ItemId, int Count) : IBaseCommand;
using Common.Application;

namespace Shop.Application.Orders.IncreaseItemCount;

public record IncreaseOrderItemCountCommand(Guid UserId, Guid ItemId, int Count) : IBaseCommand;
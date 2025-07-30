using Common.Application;

namespace Shop.Application.Sellers.EditInventory;

public record EditSellerInventoryCommand(Guid SellerId, Guid InventoryId, int Count, int Price, bool IsActive, int? DiscountPercentage) : IBaseCommand;
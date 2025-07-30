using Common.Application;

namespace Shop.Application.Sellers.AddInventory;

public record AddSellerInventoryCommand(Guid SellerId, Guid ProductId, int Count, int Price, int? DiscountPercentage) : IBaseCommand;
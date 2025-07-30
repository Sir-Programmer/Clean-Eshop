using Common.Application;

namespace Shop.Application.Sellers.Edit;

public record EditSellerCommand(Guid SellerId, string ShopName, string NationalId) : IBaseCommand;
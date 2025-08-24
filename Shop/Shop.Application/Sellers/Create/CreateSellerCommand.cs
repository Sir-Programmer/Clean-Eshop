using Common.Application;

namespace Shop.Application.Sellers.Create;

public record CreateSellerCommand(Guid UserId, string ShopName, string NationalId) : IBaseCommand<Guid>;
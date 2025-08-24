using Common.Application;

namespace Shop.Application.SiteEntities.ShippingMethods.Create;

public record CreateShippingMethodCommand(string Title, int Cost) : IBaseCommand<Guid>;
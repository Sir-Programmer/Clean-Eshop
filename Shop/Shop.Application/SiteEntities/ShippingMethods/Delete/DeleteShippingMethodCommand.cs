using Common.Application;

namespace Shop.Application.SiteEntities.ShippingMethods.Delete;

public record DeleteShippingMethodCommand(Guid ShippingMethodId) : IBaseCommand;
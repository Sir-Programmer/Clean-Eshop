using Common.Application;

namespace Shop.Application.SiteEntities.ShippingMethods.Edit;

public record EditShippingMethodCommand(Guid ShippingMethodId,string Title, int Cost) : IBaseCommand;
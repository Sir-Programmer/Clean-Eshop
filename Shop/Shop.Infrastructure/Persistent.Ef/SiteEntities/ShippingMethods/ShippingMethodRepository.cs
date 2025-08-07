using Shop.Domain.SiteEntities.ShippingMethod;
using Shop.Domain.SiteEntities.ShippingMethod.Repository;
using Shop.Infrastructure._Utilities;

namespace Shop.Infrastructure.Persistent.Ef.SiteEntities.ShippingMethods;

public class ShippingMethodRepository(ShopContext context) : BaseRepository<ShippingMethod>(context), IShippingMethodRepository
{
    public void Delete(ShippingMethod shippingMethod)
    {
        Context.Remove(shippingMethod);
    }
}
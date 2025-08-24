using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.SiteEntities.DTOs;

namespace Shop.Query.SiteEntities.ShippingMethods.GetById;

public class GetShippingMethodByIdQueryHandler(ShopContext context) : IQueryHandler<GetShippingMethodByIdQuery, ShippingMethodDto?>
{
    public async Task<ShippingMethodDto?> Handle(GetShippingMethodByIdQuery request, CancellationToken cancellationToken)
    {
        var shippingMethod =
            await context.ShippingMethods.FirstOrDefaultAsync(s => s.Id == request.ShippingMethodId, cancellationToken);
        return shippingMethod.MapShippingMethodOrNull();
    }
}
using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.SiteEntities.DTOs;

namespace Shop.Query.SiteEntities.ShippingMethods.GetList;

public class GetShippingMethodListQueryHandler(ShopContext context) : IQueryHandler<GetShippingMethodListQuery, List<ShippingMethodDto?>>
{
    public async Task<List<ShippingMethodDto?>> Handle(GetShippingMethodListQuery request, CancellationToken cancellationToken)
    {
        return await context.ShippingMethods.Select(s => s.MapShippingMethod()).ToListAsync(cancellationToken);
    }
}
using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.SiteEntities.DTOs;

namespace Shop.Query.SiteEntities.Banners.GetList;

public class GetBannerListQueryHandler (ShopContext context) : IQueryHandler<GetBannerListQuery, List<BannerDto?>>
{
    public async Task<List<BannerDto?>> Handle(GetBannerListQuery request, CancellationToken cancellationToken)
    {
        return await context.Banners.Select(b => b.MapBanner()).ToListAsync(cancellationToken);
    }
}
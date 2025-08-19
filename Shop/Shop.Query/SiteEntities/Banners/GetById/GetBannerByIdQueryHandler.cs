using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.SiteEntities.DTOs;

namespace Shop.Query.SiteEntities.Banners.GetById;

public class GetBannerByIdQueryHandler(ShopContext context) : IQueryHandler<GetBannerByIdQuery, BannerDto?>
{
    public async Task<BannerDto?> Handle(GetBannerByIdQuery request, CancellationToken cancellationToken)
    {
        var banner = await context.Banners.FirstOrDefaultAsync(b => b.Id == request.BannerId, cancellationToken: cancellationToken);
        return banner.MapBanner();
    }
}
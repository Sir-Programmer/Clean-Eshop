using Shop.Domain.SiteEntities.Banner;
using Shop.Domain.SiteEntities.Banner.Repository;
using Shop.Infrastructure._Utilities;

namespace Shop.Infrastructure.Persistent.Ef.SiteEntities.Banners;

public class BannerRepository(ShopContext context) : BaseRepository<Banner>(context), IBannerRepository
{
    public void Delete(Banner banner)
    {
        Context.Remove(banner);
    }
}
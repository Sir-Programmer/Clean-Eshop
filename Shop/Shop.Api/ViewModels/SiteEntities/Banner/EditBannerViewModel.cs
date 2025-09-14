using Shop.Domain.SiteEntities.Banner.Enums;

namespace Shop.Api.ViewModels.SiteEntities.Banner;

public class EditBannerViewModel
{
    public string Url { get; set; }
    public IFormFile ImageFile { get; set; }
    public BannerPosition Position { get; set; }
}
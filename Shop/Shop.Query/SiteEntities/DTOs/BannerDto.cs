using Common.Query;
using Shop.Domain.SiteEntities.Banner.Enums;

namespace Shop.Query.SiteEntities.DTOs;

public class BannerDto : BaseDto
{
    public string Url { get; set; }
    public string ImageName { get; set; }
    public BannerPosition BannerPosition { get; set; }
}
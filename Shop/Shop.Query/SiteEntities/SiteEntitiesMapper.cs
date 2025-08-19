using Shop.Domain.SiteEntities.Banner;
using Shop.Domain.SiteEntities.Slider;
using Shop.Query.SiteEntities.DTOs;

namespace Shop.Query.SiteEntities;

public static class SiteEntitiesMapper
{
    public static SliderDto? MapSlider(this Slider? slider)
    {
        if (slider == null) return null;
        return new SliderDto()
        {
            Id = slider.Id,
            CreationTime = slider.CreationTime,
            Title = slider.Title,
            Url = slider.Url,
            ImageName = slider.ImageName,
            IsActive = slider.IsActive
        };
    }

    public static BannerDto? MapBanner(this Banner? banner)
    {
        if (banner == null) return null;
        return new BannerDto()
        {
            Id = banner.Id,
            CreationTime = banner.CreationTime,
            Url = banner.Url,
            ImageName = banner.ImageName,
            BannerPosition = banner.BannerPosition
        };
    }
}
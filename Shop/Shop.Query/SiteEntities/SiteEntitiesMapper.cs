using Shop.Domain.SiteEntities.Banner;
using Shop.Domain.SiteEntities.ShippingMethod;
using Shop.Domain.SiteEntities.Slider;
using Shop.Query.SiteEntities.DTOs;

namespace Shop.Query.SiteEntities;

public static class SiteEntitiesMapper
{
    public static SliderDto? MapSliderOrNull(this Slider? slider)
    {
        return slider?.MapSlider();
    }
    
    public static SliderDto MapSlider(this Slider slider)
    {
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

    public static BannerDto? MapBannerOrNull(this Banner? banner)
    {
        return banner?.MapBanner();
    }
    
    public static BannerDto MapBanner(this Banner banner)
    {
        return new BannerDto()
        {
            Id = banner.Id,
            CreationTime = banner.CreationTime,
            Url = banner.Url,
            ImageName = banner.ImageName,
            BannerPosition = banner.BannerPosition
        };
    }

    public static ShippingMethodDto? MapShippingMethodOrNull(this ShippingMethod? shippingMethod)
    {
        return shippingMethod?.MapShippingMethod();
    }
    
    public static ShippingMethodDto MapShippingMethod(this ShippingMethod shippingMethod)
    {
        return new ShippingMethodDto()
        {
            Id = shippingMethod.Id,
            CreationTime = shippingMethod.CreationTime,
            Title = shippingMethod.Title,
            Cost = shippingMethod.Cost
        };
    }
}
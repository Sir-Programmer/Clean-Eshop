using Common.Domain;
using Common.Domain.Exceptions;
using Shop.Domain.SiteEntities.Banner.Enums;

namespace Shop.Domain.SiteEntities.Banner;

public class Banner : BaseEntity
{
    private Banner()
    {
        
    }
    public Banner(string url, string imageName, BannerPosition bannerPosition)
    {
        Guard(url, imageName);
        Url = url;
        ImageName = imageName;
        BannerPosition = bannerPosition;
    }
    public string Url { get; private set; }
    public string ImageName { get; private set; }
    public BannerPosition BannerPosition { get; private set; }

    public void Edit(string url, string imageName, BannerPosition bannerPosition)
    {
        Guard(url, imageName);
        Url = url;
        ImageName = imageName;
        BannerPosition = bannerPosition;
    }
    
    public void SetImageName(string imageName)
    {
        ImageName = imageName;
    }

    private void Guard(string url, string imageName)
    {
        NullOrEmptyDomainException.CheckString(url, nameof(url));
        NullOrEmptyDomainException.CheckString(imageName, nameof(imageName));
    }
}
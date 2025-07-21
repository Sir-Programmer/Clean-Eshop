using Common.Domain.Exceptions;

namespace Shop.Domain.SiteEntities.Slider;

public class Slider
{
    public Slider(string title, string url, string imageName)
    {
        Guard(title, url, imageName);
        Title = title;
        Url = url;
        ImageName = imageName;
        IsActive = true;
    }
    public string Title { get; private set; }
    public string Url { get; private set; }
    public string ImageName { get; private set; }
    public bool IsActive { get; private set; }

    public void Edit(string title, string url, string imageName, bool isActive)
    {
        Title = title;
        Url = url;
        ImageName = imageName;
        IsActive = isActive;
    }

    public void Activate()
    {
        IsActive = true;
    }

    public void DeActivate()
    {
        IsActive = false;
    }

    private void Guard(string title, string url, string imageName)
    {
        NullOrEmptyDomainException.CheckString(title, nameof(title));
        NullOrEmptyDomainException.CheckString(url, nameof(url));
        NullOrEmptyDomainException.CheckString(imageName, nameof(imageName));
    }
}
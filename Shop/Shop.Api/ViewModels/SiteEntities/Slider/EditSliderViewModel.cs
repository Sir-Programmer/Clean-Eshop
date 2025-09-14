namespace Shop.Api.ViewModels.SiteEntities.Slider;

public class EditSliderViewModel
{
    public string Title { get; set; }
    public string Url { get; set; }
    public bool IsActive { get; set; }
    public IFormFile ImageFile { get; set; }
}
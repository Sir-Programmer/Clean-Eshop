using Common.Domain.ValueObjects;

namespace Shop.Api.ViewModels.Category;

public class AddChildCategoryViewModel
{
    public string Title { get; set; }
    public string Slug { get; set; }
    public SeoDataViewModel SeoData { get; set; }
}
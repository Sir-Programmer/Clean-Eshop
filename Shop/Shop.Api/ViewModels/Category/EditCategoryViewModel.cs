using Shop.Api.ViewModels.Common;

namespace Shop.Api.ViewModels.Category;

public class EditCategoryViewModel
{
    public string Title { get; set; }
    public string Slug { get; set; }
    public SeoDataViewModel SeoData { get; set; }
}
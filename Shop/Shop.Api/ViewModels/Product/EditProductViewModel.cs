using Newtonsoft.Json;

namespace Shop.Api.ViewModels.Product;

public class EditProductViewModel
{
    public Guid ProductId { get; set; }
    public string Title { get; set; }
    public IFormFile ImageFile { get; set; }
    public string Description { get; set; }
    public Guid MainCategoryId { get; set; }
    public string? SubCategories{ get; set; }
    public string Slug { get; set; }
    public SeoDataViewModel SeoData { get; set; }
    public string Specifications { get; set; }

    public Dictionary<string, string> GetSpecification()
    {
        return JsonConvert.DeserializeObject<Dictionary<string, string>>(Specifications)!;
    }
    
    public List<string>? GetSubCategories()
    {
        return SubCategories == null ? null : JsonConvert.DeserializeObject<List<string>>(SubCategories);
    }
}
using Common.Query.Filter;

namespace Shop.Query.Products.DTOs.Filter;

public class ProductFilterParams : BaseFilterParam
{
    public string? Title { get; set; }
    public string? Slug { get; set; }
}
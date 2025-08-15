using Common.Domain.ValueObjects;

namespace Shop.Query.Products.DTOs;

public class ProductCategoryItemDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Slug { get; set; }
    public SeoData SeoData { get; set; }
}
using Shop.Domain.ProductAgg;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Products.DTOs;

namespace Shop.Query.Products;

public static class ProductMapper
{
    public static ProductDto Map(this Product product, List<ProductCategoryItemDto> categories)
    {
        var mainCategory = categories.FirstOrDefault(c => c.Id == product.MainCategoryId);

        var subCategories = categories
            .Where(c => product.SubCategories.Any(sc => sc.Id == c.Id))
            .ToList();

        return new ProductDto()
        {
            Id = product.Id,
            CreationTime = product.CreationTime,
            Title = product.Title,
            Slug = product.Slug,
            Description = product.Description,
            ImageName = product.ImageName,
            Images = product.Images.Select(p => new ProductImageDto()
            {
                ImageName = p.ImageName,
                Sequence = p.Sequence
            }).ToList(),
            MainCategory = mainCategory == null ? null : new ProductCategoryItemDto()
            {
                Id = mainCategory.Id,
                SeoData = mainCategory.SeoData,
                Title = mainCategory.Title,
                Slug = mainCategory.Slug
            },
            SeoData = product.SeoData,
            SubCategories = subCategories.Select(c => new ProductCategoryItemDto()
            {
                Id = c.Id,
                SeoData = c.SeoData,
                Title = c.Title,
                Slug = c.Slug
            }).ToList(),
            Specifications = product.Specifications.Select(p => new ProductSpecificationDto()
            {
                Key = p.Key,
                Value = p.Value,
            }).ToList()
        };
    }
}
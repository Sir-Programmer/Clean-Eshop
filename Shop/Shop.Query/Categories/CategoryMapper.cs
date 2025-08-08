using Shop.Domain.CategoryAgg;
using Shop.Query.Categories.DTOs;

namespace Shop.Query.Categories;

internal static class CategoryMapper
{
    public static CategoryDto? Map(this Category? category)
    {
        if (category == null)
            return null;

        return new CategoryDto
        {
            Title = category.Title,
            Slug = category.Slug,
            Id = category.Id,
            SeoData = category.SeoData,
            CreationTime = category.CreationTime,
            Childs = category.Childs.MapChildren()
        };
    }

    public static List<CategoryDto?> Map(this List<Category> categories)
    {
        return categories.Select(c => c.Map()).ToList();
    }

    private static List<CategoryDto> MapChildren(this List<Category> children)
    {
        return children.Select(c => new CategoryDto
        {
            Title = c.Title,
            Slug = c.Slug,
            Id = c.Id,
            SeoData = c.SeoData,
            CreationTime = c.CreationTime,
            Childs = c.Childs.MapChildren()
        }).ToList();
    }
}

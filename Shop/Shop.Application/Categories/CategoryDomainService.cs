using Shop.Domain.CategoryAgg.Repository;
using Shop.Domain.CategoryAgg.Services;

namespace Shop.Application.Categories;

public class CategoryDomainService(ICategoryRepository categoryRepository) : ICategoryDomainService
{
    public bool IsSlugExist(string slug)
    {
        return categoryRepository.Exists(c => c.Slug == slug);
    }
}
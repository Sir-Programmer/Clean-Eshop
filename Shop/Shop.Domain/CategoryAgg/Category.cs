using Common.Domain;
using Common.Domain.Exceptions;
using Common.Domain.Utils;
using Common.Domain.ValueObjects;
using Shop.Domain.CategoryAgg.Services;

namespace Shop.Domain.CategoryAgg;

public class Category : AggregateRoot
{
    private Category()
    {
        
    }
    public Category(string title, string slug, SeoData seoData, ICategoryDomainService categoryDomainService)
    {
        Guard(title, slug, categoryDomainService);
        Title = title;
        Slug = slug.ToSlug();
        SeoData = seoData;
        Childs = [];
    }
    public string Title { get; private set; }
    public string Slug { get; private set; }
    public SeoData SeoData { get; private set; }
    public Guid? ParentId { get; private set; }
    public List<Category> Childs { get; private set; }

    public void Edit(string title, string slug, SeoData seoData, ICategoryDomainService categoryDomainService)
    {
        Guard(title, slug, categoryDomainService);
        Title = title;
        Slug = slug.ToSlug();
        SeoData = seoData;
    }
    
    public void AddChild(string title, string slug, SeoData seoData, ICategoryDomainService categoryDomainService)
    {
        Childs.Add(new Category(title, slug, seoData, categoryDomainService)
        {
            ParentId = Id
        });
    }
    private void Guard(string title, string slug, ICategoryDomainService categoryDomainService)
    {
        NullOrEmptyDomainException.CheckString(title, nameof(title));
        NullOrEmptyDomainException.CheckString(slug, nameof(slug));
        if (Slug != slug.ToSlug())
            if (categoryDomainService.IsSlugExist(slug.ToSlug()))
                throw new SlugDuplicatedException();
    }
}
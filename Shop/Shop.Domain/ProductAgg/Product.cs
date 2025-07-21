using Common.Domain;
using Common.Domain.Exceptions;
using Common.Domain.ValueObjects;
using Shop.Domain.ProductAgg.Services;

namespace Shop.Domain.ProductAgg;

public class Product : AggregateRoot
{
    public Product(string title, string slug, string description, string imageName, SeoData seoData, List<Guid> categoryIds, IProductDomainService productDomainService)
    {
        Guard(title, slug, description, imageName, productDomainService);
        Title = title;
        Slug = slug;
        Description = description;
        ImageName = imageName;
        SeoData = seoData;
        CategoryIds = categoryIds;
    }

    public string Title { get; private set; }
    public string Slug { get; private set; }
    public string Description { get; private set; }
    public string ImageName { get; private set; }
    public SeoData SeoData { get; private set; }
    public List<Guid> CategoryIds  { get; private set; }
    public List<ProductImage> Images { get; private set; }
    public List<ProductSpecification> Specifications { get; private set; }

    public void Edit(string title, string slug, string description, string imageName, SeoData seoData, List<Guid> categoryIds, IProductDomainService productDomainService)
    {
        Guard(title, slug, description, imageName, productDomainService);
        Title = title;
        Slug = slug;
        Description = description;
        ImageName = imageName;
        SeoData = seoData;
    }

    public void SetImageName(string imageName)
    {
        ImageName = imageName;
    }

    public void AddImage(string imageName, int sequence)
    {
        Images.Add(new ProductImage(imageName, sequence)
        {
            ProductId = Id
        });
    }

    public void RemoveImage(Guid imageId)
    {
        var currentImage = Images.FirstOrDefault(i => i.Id == imageId);
        if (currentImage != null) Images.Remove(currentImage);
    }

    public void RemoveAllImages()
    {
        Images.Clear();
    }

    public void SetSpecifications(List<ProductSpecification> specifications)
    {
        specifications.ForEach(s => s.ProductId = Id);
        Specifications = specifications;
    }

    private void Guard(string title, string slug, string description, string imageName, IProductDomainService productDomainService)
    {
        NullOrEmptyDomainException.CheckString(title, nameof(title));
        NullOrEmptyDomainException.CheckString(slug, nameof(slug));
        NullOrEmptyDomainException.CheckString(description, nameof(description));
        NullOrEmptyDomainException.CheckString(imageName, nameof(imageName));

        if (Slug != slug)
            if (productDomainService.IsSlugExistInDb(slug))
                throw new SlugDuplicatedException();
    }
}
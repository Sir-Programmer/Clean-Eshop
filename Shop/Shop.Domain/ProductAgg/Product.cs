﻿using Common.Domain;
using Common.Domain.Exceptions;
using Common.Domain.Utils;
using Common.Domain.ValueObjects;
using Shop.Domain.ProductAgg.Services;

namespace Shop.Domain.ProductAgg;

public class Product : AggregateRoot
{
    public Product(string title, string slug, string description, string imageName, SeoData seoData, List<Guid> categoryIds, IProductDomainService productDomainService)
    {
        Guard(title, slug, description, productDomainService);
        ImageNameGuard(imageName);
        Title = title;
        Slug = slug.ToSlug();
        Description = description;
        ImageName = imageName;
        SeoData = seoData;
        CategoryIds = categoryIds;

        CategoryIds = [];
        Images = [];
        Specifications = [];
    }

    public string Title { get; private set; }
    public string Slug { get; private set; }
    public string Description { get; private set; }
    public string ImageName { get; private set; }
    public SeoData SeoData { get; private set; }
    public List<Guid> CategoryIds  { get; private set; }
    public List<ProductImage> Images { get; private set; }
    public List<ProductSpecification> Specifications { get; private set; }

    public void Edit(string title, string slug, string description, SeoData seoData, List<Guid> categoryIds, IProductDomainService productDomainService)
    {
        Guard(title, slug, description, productDomainService);
        Title = title;
        Slug = slug.ToSlug();
        Description = description;
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

    public void SetImageSequence(Guid imageId, int sequence)
    {
        var currentImage = Images.FirstOrDefault(i => i.Id == imageId);
        currentImage?.SetSequence(sequence);
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

    private void ImageNameGuard(string imageName)
    {
        NullOrEmptyDomainException.CheckString(imageName, nameof(imageName));
    }
    private void Guard(string title, string slug, string description, IProductDomainService productDomainService)
    {
        NullOrEmptyDomainException.CheckString(title, nameof(title));
        NullOrEmptyDomainException.CheckString(slug, nameof(slug));
        NullOrEmptyDomainException.CheckString(description, nameof(description));
        

        if (Slug != slug.ToSlug())
            if (productDomainService.IsSlugExist(slug.ToSlug()))
                throw new SlugDuplicatedException();
    }
}
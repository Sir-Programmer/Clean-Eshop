﻿using Common.Domain.ValueObjects;
using Common.Query;

namespace Shop.Query.Products.DTOs;

public class ProductDto : BaseDto
{
    public string Title { get; set; }
    public string Slug { get; set; }
    public string Description { get; set; }
    public string ImageName { get; set; }
    public Guid MainCategoryId { get; set; }
    public SeoData SeoData { get; set; }
    public List<ProductCategoryItemDto> SubCategories { get; set; }
    public List<ProductImageDto> Images { get; set; }
    public List<ProductSpecificationDto> Specifications { get; set; }
}
using Common.Query.Filter;
using Shop.Query.Categories.DTOs;

namespace Shop.Query.Products.DTOs.Filter;

public class ProductShopResult : BaseFilter<ProductShopDto, ProductShopFilterParams>
{
    public CategoryDto? CategoryDto { get; set; }
}
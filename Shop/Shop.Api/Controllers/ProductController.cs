using Common.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Shop.Presentation.Facade.Products;
using Shop.Query.Products.DTOs.Filter;

namespace Shop.Api.Controllers;

public class ProductController(IProductFacade productFacade) : ApiController
{
    [HttpPost]
    public async Task<ProductShopResult> GetForShop(ProductShopFilterParams filters)
    {
        return await productFacade.GetForShop(filters);
    }
}
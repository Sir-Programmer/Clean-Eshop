using Common.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.Infrastructure.Security;
using Shop.Api.ViewModels.Product;
using Shop.Application.Products.Create;
using Shop.Domain.RoleAgg.Enums;
using Shop.Presentation.Facade.Products;
using Shop.Query.Products.DTOs;
using Shop.Query.Products.DTOs.Filter;

namespace Shop.Api.Controllers;

[PermissionChecker(Permission.CrudProduct)]
public class ProductController(IProductFacade productFacade) : ApiController
{

    [HttpGet]
    [AllowAnonymous]
    public async Task<ApiResult<ProductFilterResult?>> GetByFilter([FromQuery] ProductFilterParams filterParams)
    {
        var result = await productFacade.GetByFilter(filterParams);
        return QueryResult(result);
    }

    [HttpGet("shop")]
    [AllowAnonymous]
    public async Task<ApiResult<ProductShopResult?>> GetForShop([FromQuery] ProductShopFilterParams filterParams)
    {
        var result = await productFacade.GetForShop(filterParams);
        return QueryResult(result);
    }

    [HttpGet("{id:guid}")]
    [AllowAnonymous]
    public async Task<ApiResult<ProductDto?>> GetById(Guid id)
    {
        var result = await productFacade.GetById(id);
        return QueryResult(result);
    }

    [HttpGet("slug/{slug}")]
    [AllowAnonymous]
    public async Task<ApiResult<ProductDto?>> GetBySlug(string slug)
    {
        var result = await productFacade.GetBySlug(slug);
        return QueryResult(result);
    }
    
    [HttpGet("details/{slug}")]
    [AllowAnonymous]
    public async Task<ApiResult<ProductDetailsDto?>> GetDetails(string slug)
    {
        var result = await productFacade.GetDetails(slug);
        return QueryResult(result);
    }

    
    [HttpPost]
    public async Task<ApiResult<Guid>> CreateProduct([FromForm] CreateProductViewModel viewModel)
    {
        var subCategoryIds = (viewModel.GetSubCategories() ?? []).Select(Guid.Parse).ToList();
        
        var command = new CreateProductCommand(viewModel.Title, viewModel.Slug, viewModel.Description,
            viewModel.ImageFile, viewModel.SeoData.Map(), viewModel.MainCategoryId, subCategoryIds,
            viewModel.GetSpecification());
        
        return CommandResult(await productFacade.Create(command));
    }
}
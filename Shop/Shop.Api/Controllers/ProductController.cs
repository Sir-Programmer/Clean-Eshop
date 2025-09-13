using Common.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.Infrastructure.Security;
using Shop.Api.ViewModels.Product;
using Shop.Application.Products.AddImage;
using Shop.Application.Products.Create;
using Shop.Application.Products.Edit;
using Shop.Application.Products.EditImageSequence;
using Shop.Application.Products.RemoveImage;
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
    public async Task<ApiResult<Guid>> Create([FromForm] CreateProductViewModel vm)
    {
        var subCategoryIds = (vm.GetSubCategories() ?? []).Select(Guid.Parse).ToList();
        
        var command = new CreateProductCommand(vm.Title, vm.Slug, vm.Description,
            vm.ImageFile, vm.SeoData.Map(), vm.MainCategoryId, subCategoryIds,
            vm.GetSpecification());
        
        return CommandResult(await productFacade.Create(command));
    }
    
    [HttpPut]
    public async Task<ApiResult> Edit([FromForm] EditProductViewModel vm)
    {
        var subCategoryIds = (vm.GetSubCategories() ?? []).Select(Guid.Parse).ToList();
        
        var command = new EditProductCommand(vm.ProductId, vm.Title, vm.Slug, vm.Description,
            vm.ImageFile, vm.SeoData.Map(), vm.MainCategoryId, subCategoryIds,
            vm.GetSpecification());
        
        return CommandResult(await productFacade.Edit(command));
    }

    [HttpPost("{id:guid}/images")]
    public async Task<ApiResult> AddImage(Guid id, [FromForm] AddProductImageViewModel vm)
    {
        var command = await productFacade.AddImage(new AddProductImageCommand(id, vm.ImageFile, vm.Sequence));
        return CommandResult(command);
    }
    
    [HttpDelete("{id:guid}/images/{imageId:guid}")]
    public async Task<ApiResult> RemoveImage(Guid id,  Guid imageId)
    {
        var command = await productFacade.RemoveImage(new RemoveProductImageCommand(id, imageId));
        return CommandResult(command);
    }
    
    [HttpPut("{id:guid}/images/{imageId:guid}/sequence")]
    public async Task<ApiResult> EditImageSequence(Guid id,  Guid imageId, EditProductImageSequenceViewModel vm)
    {
        var command = await productFacade.EditImageSequence(new EditProductImageSequenceCommand(id, imageId, vm.Sequence));
        return CommandResult(command);
    }
}
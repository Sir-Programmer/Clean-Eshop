using System.Net;
using Common.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.Infrastructure.Security;
using Shop.Api.ViewModels.Category;
using Shop.Application.Categories.AddChild;
using Shop.Application.Categories.Create;
using Shop.Application.Categories.Edit;
using Shop.Domain.RoleAgg.Enums;
using Shop.Presentation.Facade.Categories;
using Shop.Query.Categories.DTOs;

namespace Shop.Api.Controllers;

[PermissionChecker(Permission.PanelAdmin)]
public class CategoryController(ICategoryFacade categoryFacade) : ApiController
{
    [HttpGet]
    public async Task<ApiResult<List<CategoryDto>>> GetList()
    {
        return QueryResult(await categoryFacade.GetList());
    }
    
    [HttpGet("{id:guid}")]
    public async Task<ApiResult<CategoryDto?>> GetById(Guid id)
    {
        return QueryResult(await categoryFacade.GetById(id));
    }
    
    [HttpGet("{parentId:guid}/children")]
    public async Task<ApiResult<List<CategoryDto>>> GetByParentId(Guid parentId)
    {
        return QueryResult(await categoryFacade.GetByParentId(parentId));
    }
    
    [HttpPost]
    public async Task<ApiResult<Guid>> Create(CreateCategoryCommand command)
    {
        var result = await categoryFacade.Create(command);
        var url = Url.Action("GetCategoryById", "Category", new { id = result.Data }, Request.Scheme);
        return CommandResult(result, statusCode: HttpStatusCode.Created, locationUrl: url);
    }
    [HttpPost("{parentId:guid}/children")]
    public async Task<ApiResult<Guid>> CreateChild(Guid parentId, AddChildCategoryViewModel vm)
    {
        var result = await categoryFacade.AddChild(new AddChildCategoryCommand(parentId, vm.Title, vm.Slug, vm.SeoData.Map()));
        var url = Url.Action("GetCategoryById", "Category", new { id = result.Data }, Request.Scheme);
        return CommandResult(result, statusCode: HttpStatusCode.Created, locationUrl: url);
    }

    [HttpPut("{id:guid}")]
    public async Task<ApiResult> Edit(Guid id, EditCategoryViewModel vm)
    {
        return CommandResult(await categoryFacade.Edit(new EditCategoryCommand(id, vm.Title, vm.Slug, vm.SeoData.Map())));
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<ApiResult> Delete(Guid id)
    {
        return CommandResult(await categoryFacade.Delete(id));
    }
}
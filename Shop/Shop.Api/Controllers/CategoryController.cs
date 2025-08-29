using System.Net;
using Common.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Categories.AddChild;
using Shop.Application.Categories.Create;
using Shop.Application.Categories.Edit;
using Shop.Presentation.Facade.Categories;
using Shop.Query.Categories.DTOs;

namespace Shop.Api.Controllers;

public class CategoryController(ICategoryFacade categoryFacade) : ApiController
{
    [HttpGet]
    public async Task<ApiResult<List<CategoryDto>>> GetCategories()
    {
        return QueryResult(await categoryFacade.GetList());
    }
    
    [HttpGet("{categoryId:guid}")]
    public async Task<ApiResult<CategoryDto?>> GetCategoryById(Guid categoryId)
    {
        return QueryResult(await categoryFacade.GetById(categoryId));
    }
    
    [HttpGet("GetChilds/{parentId:guid}")]
    public async Task<ApiResult<List<CategoryDto>>> GetCategoriesByParentId(Guid parentId)
    {
        return QueryResult(await categoryFacade.GetByParentId(parentId));
    }
    
    [HttpPost]
    public async Task<ApiResult<Guid>> CreateCategory(CreateCategoryCommand command)
    {
        var result = await categoryFacade.Create(command);
        var url = Url.Action("GetCategoryById", "Category", new { categoryId = result.Data }, Request.Scheme);
        return CommandResult(result, statusCode: HttpStatusCode.Created, locationUrl: url);
    }
    [HttpPost("AddChild")]
    public async Task<ApiResult<Guid>> CreateCategory(AddChildCategoryCommand command)
    {
        var result = await categoryFacade.AddChild(command);
        var url = Url.Action("GetCategoryById", "Category", new { categoryId = result.Data }, Request.Scheme);
        return CommandResult(result, statusCode: HttpStatusCode.Created, locationUrl: url);
    }

    [HttpPut]
    public async Task<ApiResult> EditCategory(EditCategoryCommand command)
    {
        return CommandResult(await categoryFacade.Edit(command));
    }
    
    [HttpDelete("{categoryId:guid}")]
    public async Task<ApiResult> Delete(Guid categoryId)
    {
        return CommandResult(await categoryFacade.Delete(categoryId));
    }
}
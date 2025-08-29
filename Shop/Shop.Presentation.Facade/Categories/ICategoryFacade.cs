using Common.Application.OperationResults;
using Shop.Application.Categories.AddChild;
using Shop.Application.Categories.Create;
using Shop.Application.Categories.Edit;
using Shop.Application.Categories.Remove;
using Shop.Query.Categories.DTOs;

namespace Shop.Presentation.Facade.Categories;

public interface ICategoryFacade
{
    Task<OperationResult<Guid>> Create(CreateCategoryCommand command);
    Task<OperationResult<Guid>> AddChild(AddChildCategoryCommand command);
    Task<OperationResult> Edit(EditCategoryCommand command);
    Task<OperationResult> Delete(Guid categoryId);
    
    
    Task<CategoryDto?> GetById(Guid id);
    Task<List<CategoryDto>> GetByParentId(Guid parentId);
    Task<List<CategoryDto>> GetList();
}
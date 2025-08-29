using Common.Application.OperationResults;
using MediatR;
using Shop.Application.Categories.AddChild;
using Shop.Application.Categories.Create;
using Shop.Application.Categories.Edit;
using Shop.Application.Categories.Remove;
using Shop.Query.Categories.DTOs;
using Shop.Query.Categories.GetById;
using Shop.Query.Categories.GetByParentId;
using Shop.Query.Categories.GetList;

namespace Shop.Presentation.Facade.Categories;

public class CategoryFacade(IMediator mediator) : ICategoryFacade
{
    public async Task<OperationResult<Guid>> Create(CreateCategoryCommand command)
    {
        return await mediator.Send(command);
    }

    public async Task<OperationResult<Guid>> AddChild(AddChildCategoryCommand command)
    {
        return await mediator.Send(command);
    }

    public async Task<OperationResult> Edit(EditCategoryCommand command)
    {
        return await mediator.Send(command);
    }

    public async Task<OperationResult> Delete(Guid categoryId)
    {
        return await mediator.Send(new RemoveCategoryCommand(categoryId));
    }

    public async Task<CategoryDto?> GetById(Guid id)
    {
        return await mediator.Send(new GetCategoryByIdQuery(id));
    }

    public async Task<List<CategoryDto>> GetByParentId(Guid parentId)
    {
        return await mediator.Send(new GetCategoryByParentIdQuery(parentId));
    }

    public async Task<List<CategoryDto>> GetList()
    {
        return await mediator.Send(new GetCategoryListQuery());
    }
}
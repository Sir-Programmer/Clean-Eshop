using Common.Application.OperationResults;
using MediatR;
using Shop.Application.Products.AddImage;
using Shop.Application.Products.Create;
using Shop.Application.Products.Edit;
using Shop.Application.Products.EditImageSequence;
using Shop.Application.Products.RemoveImage;
using Shop.Query.Products.DTOs;
using Shop.Query.Products.DTOs.Filter;
using Shop.Query.Products.GetByFilter;
using Shop.Query.Products.GetById;
using Shop.Query.Products.GetBySlug;
using Shop.Query.Products.GetForShop;

namespace Shop.Presentation.Facade.Products;

public class ProductFacade(IMediator mediator) : IProductFacade
{
    public async Task<OperationResult<Guid>> Create(CreateProductCommand command)
    {
        return await mediator.Send(command);
    }

    public async Task<OperationResult> Edit(EditProductCommand command)
    {
        return await mediator.Send(command);
    }

    public async Task<OperationResult> AddImage(AddProductImageCommand command)
    {
        return await mediator.Send(command);
    }

    public async Task<OperationResult> EditImageSequence(EditProductImageSequenceCommand command)
    {
        return await mediator.Send(command);
    }

    public async Task<OperationResult> RemoveImage(RemoveProductImageCommand command)
    {
        return await mediator.Send(command);
    }

    public async Task<ProductFilterResult> GetByFilter(ProductFilterParams filters)
    {
        return await mediator.Send(new GetProductByFilterQuery(filters));
    }

    public async Task<ProductShopResult> GetForShop(ProductShopFilterParams filters)
    {
        return await mediator.Send(new GetProductForShopQuery(filters));
    }

    public async Task<ProductDto?> GetById(Guid id)
    {
        return await mediator.Send(new GetProductByIdQuery(id));
    }

    public async Task<ProductDto?> GetBySlug(string slug)
    {
        return await mediator.Send(new GetProductBySlugQuery(slug));
    }
}
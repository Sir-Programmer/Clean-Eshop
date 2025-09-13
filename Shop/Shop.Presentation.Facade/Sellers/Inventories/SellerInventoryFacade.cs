using Common.Application.OperationResults;
using MediatR;
using Shop.Application.Sellers.AddInventory;
using Shop.Application.Sellers.EditInventory;
using Shop.Query.Sellers.DTOs;
using Shop.Query.Sellers.DTOs.Filter;
using Shop.Query.Sellers.Inventories.GetByFilter;
using Shop.Query.Sellers.Inventories.GetById;
using Shop.Query.Sellers.Inventories.GetByProductId;

namespace Shop.Presentation.Facade.Sellers.Inventories;

public class SellerInventoryFacade(IMediator mediator) : ISellerInventoryFacade
{
    public async Task<OperationResult> AddInventory(AddSellerInventoryCommand command)
    {
        return await mediator.Send(command);
    }

    public async Task<OperationResult> EditInventory(EditSellerInventoryCommand command)
    {
        return await mediator.Send(command);
    }

    public async Task<InventoryDto?> GetById(Guid id)
    {
        return await mediator.Send(new GetSellerInventoryByIdQuery(id));
    }

    public async Task<List<InventoryDto>> GetByProductId(Guid productId)
    {
        return await mediator.Send(new GetSellerInventoryByProductIdQuery(productId));
    }

    public async Task<SellerInventoryFilterResult> GetByFilter(SellerInventoryFilterParams filters)
    {
        return await mediator.Send(new GetSellerInventoryByFilterQuery(filters));
    }
}
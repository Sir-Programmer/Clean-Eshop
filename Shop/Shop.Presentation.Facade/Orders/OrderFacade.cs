using Common.Application.OperationResults;
using MediatR;
using Shop.Application.Orders.AddItem;
using Shop.Application.Orders.Checkout;
using Shop.Application.Orders.DecreaseItemCount;
using Shop.Application.Orders.Finally;
using Shop.Application.Orders.IncreaseItemCount;
using Shop.Application.Orders.RemoveItem;
using Shop.Application.Orders.SendOrder;
using Shop.Application.Orders.SetDiscount;
using Shop.Query.Orders.DTOs;
using Shop.Query.Orders.DTOs.Filter;
using Shop.Query.Orders.GetByFilter;
using Shop.Query.Orders.GetById;
using Shop.Query.Orders.GetCurrent;

namespace Shop.Presentation.Facade.Orders;

public class OrderFacade(IMediator mediator) : IOrderFacade
{
    public async Task<OperationResult> AddItem(AddOrderItemCommand command)
    {
        return await mediator.Send(command);
    }

    public async Task<OperationResult> RemoveItem(RemoveOrderItemCommand command)
    {
        return await mediator.Send(command);
    }

    public async Task<OperationResult> Checkout(CheckoutOrderCommand command)
    {
        return await mediator.Send(command);
    }

    public async Task<OperationResult> DecreaseItemCount(DecreaseOrderItemCountCommand command)
    {
        return await mediator.Send(command);
    }

    public async Task<OperationResult> IncreaseItemCount(IncreaseOrderItemCountCommand command)
    {
        return await mediator.Send(command);
    }

    public async Task<OperationResult> Finally(FinallyOrderCommand command)
    {
        return await mediator.Send(command);
    }

    public async Task<OperationResult> SetDiscount(SetOrderDiscountCommand command)
    {
        return await mediator.Send(command);
    }

    public async Task<OperationResult> Send(SendOrderCommand command)
    {
        return await mediator.Send(command);
    }

    public async Task<OrderFilterResult> GetByFilter(OrderFilterParams filters)
    {
        return await mediator.Send(new GetOrderByFilterQuery(filters));
    }

    public async Task<OrderDto?> GetById(Guid id)
    {
        return await mediator.Send(new GetOrderByIdQuery(id));
    }

    public async Task<OrderDto?> GetCurrentUserOrder(Guid userId)
    {
        return await mediator.Send(new GetCurrentUserOrderQuery(userId));
    }
}
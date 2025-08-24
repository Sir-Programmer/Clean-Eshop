using Common.Application.OperationResults;
using Shop.Application.Orders.AddItem;
using Shop.Application.Orders.Checkout;
using Shop.Application.Orders.DecreaseItemCount;
using Shop.Application.Orders.Finally;
using Shop.Application.Orders.IncreaseItemCount;
using Shop.Application.Orders.RemoveItem;
using Shop.Application.Orders.SendOrder;
using Shop.Query.Orders.DTOs;
using Shop.Query.Orders.DTOs.Filter;

namespace Shop.Presentation.Facade.Orders;

public interface IOrderFacade
{
    Task<OperationResult> AddItem(AddOrderItemCommand command);
    Task<OperationResult> RemoveItem(RemoveOrderItemCommand command);
    Task<OperationResult> Checkout(CheckoutOrderCommand command);
    Task<OperationResult> DecreaseItemCount(DecreaseOrderItemCountCommand command);
    Task<OperationResult> IncreaseItemCount(IncreaseOrderItemCountCommand command);
    Task<OperationResult> Finally(FinallyOrderCommand command);
    Task<OperationResult> Send(SendOrderCommand command);

    
    Task<OrderFilterResult> GetByFilter(OrderFilterParams filters);
    Task<OrderDto?> GetById(Guid id);
    Task<OrderDto?> GetCurrentUserOrder(Guid userId);
}
using Shop.Query.Orders.DTOs;

namespace Shop.Query.Orders.Services;

public interface IOrderQueryService
{
    Task<List<OrderItemDto>> GetOrderItems(Guid orderId);
}
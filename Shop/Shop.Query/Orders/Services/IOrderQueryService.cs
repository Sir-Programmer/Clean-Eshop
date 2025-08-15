using Shop.Query.Orders.DTOs;

namespace Shop.Query.Orders.Services;

public interface IOrderQueryService
{
    Task<List<OrderItemDto>> GetOrderItemsAsync(Guid orderId);
    Task<string?> GetUserFullNameAsync(Guid userId);
}
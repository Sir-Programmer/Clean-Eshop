using Shop.Domain.OrderAgg;
using Shop.Query.Orders.DTOs;
using Shop.Query.Orders.DTOs.Filter;

namespace Shop.Query.Orders;

public static class OrderMapper
{
    public static OrderDto? MapOrNull(this Order? order, string? userFullName)
    {
        return order?.Map(userFullName);
    }
    
    public static OrderDto Map(this Order order, string? userFullName)
    {
        return new OrderDto
        {
            Id = order.Id,
            CreationTime = order.CreationTime,
            UserId = order.UserId,
            UserFullName = userFullName ?? "",
            Status = order.Status,
            Address = order.Address,
            Discount = order.Discount,
            ShippingMethod = order.ShippingMethod,
            LastUpdate = order.LastUpdate,
            Items = []
        };
    }

    public static OrderFilterDto MapFilter(this Order order, string? userFullName)
    {
        return new OrderFilterDto
        {
            Id = order.Id,
            CreationTime = order.CreationTime,
            UserId = order.UserId,
            UserFullName = userFullName ?? "",
            Status = order.Status,
            Province = order.Address?.Province,
            City = order.Address?.City,
            ShippingType = order.ShippingMethod?.ShippingType,
            TotalPrice = order.TotalPrice,
            TotalItemCount = order.TotalItems
        };
    }
}
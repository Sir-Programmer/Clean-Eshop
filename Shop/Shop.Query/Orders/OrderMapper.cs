using Dapper;
using Shop.Domain.OrderAgg;
using Shop.Infrastructure.Persistent.Dapper;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Orders.DTOs;
using Shop.Query.Orders.DTOs.Filter;

namespace Shop.Query.Orders;

public static class OrderMapper
{
    public static OrderDto? Map(this Order? order, ShopContext context)
    {
        if (order == null) return null;
        var userFullName = context.Users.Where(u => u.Id == order.UserId).Select(u => $"{u.Name} {u.Family}")
            .FirstOrDefault();
        return new OrderDto()
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

    public static async Task<List<OrderItemDto>> GetOrderItems(this OrderDto order, DapperContext dapperContext)
    {
        using var connection = dapperContext.CreateConnection();
        const string sql = $"""
                                SELECT o.Id, 
                                       p.Title AS ProductTitle, 
                                       p.Slug AS ProductSlug, 
                                       p.ImageName AS ProductImageName, 
                                       s.ShopName, 
                                       o.OrderId, 
                                       o.InventoryId, 
                                       o.Count, 
                                       o.Price 
                                FROM {DapperContext.OrderItems} o 
                                INNER JOIN {DapperContext.Inventories} i ON i.Id = o.InventoryId
                                INNER JOIN {DapperContext.Products} p ON p.Id = i.ProductId
                                INNER JOIN {DapperContext.Sellers} s ON s.Id = i.SellerId
                                WHERE o.OrderId = @orderId
                            """;
        var result = await connection.QueryAsync<OrderItemDto>(sql, new { orderId = order.Id });
        return result.ToList();
    }

    public static OrderFilterDto? MapFilter(this Order? order, ShopContext context)
    {
        if (order == null) return null;
        var userFullName = context.Users.Where(u => u.Id == order.UserId).Select(u => u.Name).FirstOrDefault();
        return new OrderFilterDto()
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
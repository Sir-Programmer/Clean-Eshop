using Dapper;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Dapper;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Orders.DTOs;

namespace Shop.Query.Orders.Services;

public class OrderQueryService(DapperContext dapperContext, ShopContext context) : IOrderQueryService
{
    public async Task<string?> GetUserFullNameAsync(Guid userId)
    {
        var user = await context.Users.FirstOrDefaultAsync(x => x.Id == userId);
        return user == null ? null : $"{user.Name} {user.Family}";
    }
    public async Task<List<OrderItemDto>> GetOrderItemsAsync(Guid orderId)
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
        var result = await connection.QueryAsync<OrderItemDto>(sql, new { orderId });
        return result.ToList();
    }
}
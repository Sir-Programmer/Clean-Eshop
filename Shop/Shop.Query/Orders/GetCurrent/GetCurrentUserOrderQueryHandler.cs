using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Dapper;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Orders.DTOs;
using Shop.Query.Orders.Services;

namespace Shop.Query.Orders.GetCurrent;

public class GetCurrentUserOrderQueryHandler(ShopContext context, IOrderQueryService orderQueryService) : IQueryHandler<GetCurrentUserOrderQuery, OrderDto?>
{
    public async Task<OrderDto?> Handle(GetCurrentUserOrderQuery request, CancellationToken cancellationToken)
    {
        var order = await context.Orders.SingleOrDefaultAsync(o => o.UserId == request.UserId, cancellationToken: cancellationToken);
        
        if (order == null) return null;
        
        var userFullName = await context.Users
            .Where(u => u.Id == order.UserId)
            .Select(u => $"{u.Name} {u.Family}")
            .FirstOrDefaultAsync(cancellationToken);
        
        var orderDto = order.Map(userFullName);
        
        if (orderDto == null) return null;
        orderDto.Items = await orderQueryService.GetOrderItems(orderDto.Id);
        
        return orderDto;
    }
}
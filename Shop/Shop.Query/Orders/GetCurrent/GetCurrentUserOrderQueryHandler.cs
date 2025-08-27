using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Orders.DTOs;
using Shop.Query.Orders.Services;

namespace Shop.Query.Orders.GetCurrent;

public class GetCurrentUserOrderQueryHandler(ShopContext context, IOrderQueryService orderQueryService) : IQueryHandler<GetCurrentUserOrderQuery, OrderDto?>
{
    public async Task<OrderDto?> Handle(GetCurrentUserOrderQuery request, CancellationToken cancellationToken)
    {
        var order = await context.Orders.SingleOrDefaultAsync(o => o.UserId == request.UserId, cancellationToken);
        
        if (order == null) return null;
        
        var userFullName = await orderQueryService.GetUserFullNameAsync(order.UserId);
        
        var orderDto = order.MapOrNull(userFullName);
        
        if (orderDto == null) return null;
        orderDto.Items = await orderQueryService.GetOrderItemsAsync(orderDto.Id);
        
        return orderDto;
    }
}
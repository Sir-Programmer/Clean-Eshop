using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Dapper;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Orders.DTOs;
using Shop.Query.Orders.Services;

namespace Shop.Query.Orders.GetById;

public class GetOrderByIdQueryHandler(ShopContext context, IOrderQueryService orderQueryService) : IQueryHandler<GetOrderByIdQuery, OrderDto?>
{
    public async Task<OrderDto?> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        var order = await context.Orders.SingleOrDefaultAsync(o => o.Id == request.OrderId, cancellationToken);
        
        if (order == null) return null;
        
        var userFullName = await orderQueryService.GetUserFullNameAsync(order.UserId);
        
        var orderDto = order.MapOrNull(userFullName);
        
        if (orderDto == null) return null;
        orderDto.Items = await orderQueryService.GetOrderItemsAsync(orderDto.Id);
        
        return orderDto;
    }
}
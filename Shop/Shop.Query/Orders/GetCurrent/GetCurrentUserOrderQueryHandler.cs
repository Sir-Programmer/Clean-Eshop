using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Dapper;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Orders.DTOs;

namespace Shop.Query.Orders.GetCurrent;

public class GetCurrentUserOrderQueryHandler(ShopContext context, DapperContext dapperContext) : IQueryHandler<GetCurrentUserOrderQuery, OrderDto?>
{
    public async Task<OrderDto?> Handle(GetCurrentUserOrderQuery request, CancellationToken cancellationToken)
    {
        var order = await context.Orders.SingleOrDefaultAsync(o => o.UserId == request.UserId, cancellationToken: cancellationToken);
        var orderDto = order.Map(context);
        if (orderDto == null) return null;
        orderDto.Items = await orderDto.GetOrderItems(dapperContext);
        return orderDto;
    }
}
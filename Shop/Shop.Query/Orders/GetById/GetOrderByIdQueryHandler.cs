using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Dapper;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Orders.DTOs;

namespace Shop.Query.Orders.GetById;

public class GetOrderByIdQueryHandler(ShopContext context, DapperContext dapperContext) : IQueryHandler<GetOrderByIdQuery, OrderDto?>
{
    public async Task<OrderDto?> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        var order = await context.Orders.SingleOrDefaultAsync(o => o.Id == request.OrderId, cancellationToken: cancellationToken);
        var orderDto = order.Map(context);
        if (orderDto == null) return null;
        orderDto.Items = await orderDto.GetOrderItems(dapperContext);
        return orderDto;
    }
}
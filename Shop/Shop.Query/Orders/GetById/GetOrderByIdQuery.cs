using Common.Query;
using Shop.Query.Orders.DTOs;

namespace Shop.Query.Orders.GetById;

public record GetOrderByIdQuery(Guid OrderId) : IQuery<OrderDto?>;
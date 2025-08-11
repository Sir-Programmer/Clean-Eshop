using Common.Query;
using Shop.Query.Orders.DTOs;

namespace Shop.Query.Orders.GetCurrent;

public record GetCurrentUserOrderQuery(Guid UserId) : IQuery<OrderDto?>;
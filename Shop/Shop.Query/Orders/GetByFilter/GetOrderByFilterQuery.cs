using Common.Query;
using Shop.Infrastructure.Persistent.Dapper;
using Shop.Query.Orders.DTOs.Filter;

namespace Shop.Query.Orders.GetByFilter;

public class GetOrderByFilterQuery(OrderFilterParams filterParams) : QueryFilter<OrderFilterResult, OrderFilterParams>(filterParams);
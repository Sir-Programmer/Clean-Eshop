using Common.Query;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Orders.DTOs.Filter;
using Shop.Query.Orders.Services;

namespace Shop.Query.Orders.GetByFilter;

public class GetOrderByFilterQueryHandler(ShopContext context, IOrderQueryService orderQueryService) : IQueryHandler<GetOrderByFilterQuery, OrderFilterResult>
{
    public async Task<OrderFilterResult> Handle(GetOrderByFilterQuery request, CancellationToken cancellationToken)
    {
        var filters = request.FilterParams;

        var query = context.Orders
            .OrderByDescending(o => o.CreationTime)
            .AsQueryable();

        if (filters.UserId != null)
            query = query.Where(o => o.UserId == filters.UserId);
        if (filters.StartDate != null)
            query = query.Where(o => o.CreationTime >= filters.StartDate.Value);
        if (filters.EndDate != null)
            query = query.Where(o => o.CreationTime <= filters.EndDate.Value);
        if (filters.Status != null)
            query = query.Where(o => o.Status == filters.Status);

        var orders =  query
            .Skip((filters.PageId - 1) * filters.Take)
            .Take(filters.Take)
            .ToList();

        var data = new List<OrderFilterDto>();
        foreach (var order in orders)
        {
            var fullName = await orderQueryService.GetUserFullNameAsync(order.UserId);
            data.Add(order.MapFilter(fullName));
        }

        var result = new OrderFilterResult
        {
            Data = data,
            FilterParams = filters
        };
        result.GeneratePaging(query.Count(), filters.Take, filters.PageId);

        return result;
    }
}
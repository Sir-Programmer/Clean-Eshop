using Common.Query;
using Common.Query.Filter;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Orders.DTOs.Filter;
using Shop.Query.Orders.Services;

namespace Shop.Query.Orders.GetByFilter;

public class GetOrderByFilterQueryHandler(ShopContext context, IOrderQueryService orderQueryService) : IQueryHandler<GetOrderByFilterQuery, OrderFilterResult>
{
    public async Task<OrderFilterResult> Handle(GetOrderByFilterQuery request, CancellationToken cancellationToken)
    {
        var @params = request.FilterParams;

        var query = context.Orders
            .OrderByDescending(o => o.CreationTime)
            .AsQueryable();

        if (@params.UserId != null)
            query = query.Where(o => o.UserId == @params.UserId);
        if (@params.StartDate != null)
            query = query.Where(o => o.CreationTime >= @params.StartDate.Value);
        if (@params.EndDate != null)
            query = query.Where(o => o.CreationTime <= @params.EndDate.Value);
        if (@params.Status != null)
            query = query.Where(o => o.Status == @params.Status);

        var orders =  query
            .Skip((@params.PageId - 1) * @params.Take)
            .Take(@params.Take)
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
            FilterParams = @params
        };
        result.GeneratePaging(query.Count(), @params.Take, @params.PageId);

        return result;
    }
}
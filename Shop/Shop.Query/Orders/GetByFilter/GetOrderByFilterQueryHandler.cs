using Common.Query;
using Common.Query.Filter;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Orders.DTOs.Filter;

namespace Shop.Query.Orders.GetByFilter;

public class GetOrderByFilterQueryHandler(ShopContext context) : IQueryHandler<GetOrderByFilterQuery, OrderFilterResult>
{
    public Task<OrderFilterResult> Handle(GetOrderByFilterQuery request, CancellationToken cancellationToken)
    {
        var @params = request.FilterParams;
        
        
        var query = context.Orders.OrderByDescending(o => o.CreationTime).AsQueryable();
        if (@params.UserId != null)
            query = query.Where(o => o.UserId == @params.UserId);
        if (@params.StartDate != null)
            query = query.Where(o => o.CreationTime >= @params.StartDate.Value);
        if  (@params.EndDate != null)
            query = query.Where(o => o.CreationTime <= @params.EndDate.Value);
        if (@params.Status != null)
            query = query.Where(o => o.Status == @params.Status);
        
        var ordersWithUsers = query
            .Select(o => new
            {
                Order = o,
                UserFullName = context.Users
                    .Where(u => u.Id == o.UserId)
                    .Select(u => u.Name + " " + u.Family)
                    .FirstOrDefault()
            });
        
        
        var data = ordersWithUsers
            .AsQueryable()
            .Select(x => x.Order.MapFilter(x.UserFullName))
            .ToSafePagedList(@params.PageId, @params.Take)
            .ToList();
        
        var result = new OrderFilterResult
        {
            Data = data,
            FilterParams = @params
        };
        
        result.GeneratePaging(query.Count(), @params.Take, @params.PageId);
        return Task.FromResult(result);
    }
}
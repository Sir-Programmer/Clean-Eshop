using Common.Query;
using Common.Query.Filter;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Orders.DTOs.Filter;

namespace Shop.Query.Orders.GetByFilter;

public class GetOrderByFilterQueryHandler(ShopContext context) : IQueryHandler<GetOrderByFilterQuery, OrderFilterResult>
{
    public async Task<OrderFilterResult> Handle(GetOrderByFilterQuery request, CancellationToken cancellationToken)
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
        
        var data = query.Select(o => o.MapFilter(context)).ToSafePagedList(@params.PageId, @params.Take).ToList();
        
        var result = new OrderFilterResult
        {
            Data = data,
            FilterParams = @params
        }; 
        
        return result;
    }
}
using Common.Query;
using Common.Query.Filter;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Users.DTOs.Filter;

namespace Shop.Query.Users.GetByFilter;

public class GetUserByFilterQueryHandler(ShopContext context) : IQueryHandler<GetUserByFilterQuery, UserFilterResult>
{
    public Task<UserFilterResult> Handle(GetUserByFilterQuery request, CancellationToken cancellationToken)
    {
        var filters = request.FilterParams;
        var query = context.Users.OrderByDescending(u => u.CreationTime).AsQueryable();
        if (!string.IsNullOrEmpty(filters.Email))
            query = query.Where(u => u.Email == filters.Email);
        if (!string.IsNullOrEmpty(filters.PhoneNumber))
            query = query.Where(u => u.PhoneNumber == filters.PhoneNumber);
        var data = query.Select(u => u.MapFilter()).ToSafePagedList(filters.PageId, filters.Take).ToList();
        var result = new UserFilterResult
        {
            Data = data,
            FilterParams = filters
        };
        result.GeneratePaging(query.Count(), filters.Take, filters.PageId);
        return Task.FromResult(result);
    }
}
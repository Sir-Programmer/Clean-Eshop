using Common.Query;
using Common.Query.Filter;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Users.DTOs.Filter;

namespace Shop.Query.Users.GetByFilter;

public class GetUserByFilterQueryHandler(ShopContext context) : IQueryHandler<GetUserByFilterQuery, UserFilterResult>
{
    public Task<UserFilterResult> Handle(GetUserByFilterQuery request, CancellationToken cancellationToken)
    {
        var @params = request.FilterParams;
        var query = context.Users.OrderByDescending(u => u.CreationTime).AsQueryable();
        if (!string.IsNullOrEmpty(@params.Email))
            query = query.Where(u => u.Email == @params.Email);
        if (!string.IsNullOrEmpty(@params.PhoneNumber))
            query = query.Where(u => u.PhoneNumber == @params.PhoneNumber);
        var data = query.Select(u => u.MapFilter()).ToSafePagedList(@params.PageId, @params.Take).ToList();
        var result = new UserFilterResult
        {
            Data = data,
            FilterParams = @params
        };
        result.GeneratePaging(query.Count(), @params.Take, @params.PageId);
        return Task.FromResult(result);
    }
}
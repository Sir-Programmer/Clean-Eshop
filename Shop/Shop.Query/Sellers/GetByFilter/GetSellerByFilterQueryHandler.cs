using Common.Query;
using Common.Query.Filter;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Sellers.DTOs.Filter;

namespace Shop.Query.Sellers.GetByFilter;

public class GetSellerByFilterQueryHandler(ShopContext context) : IQueryHandler<GetSellerByFilterQuery, SellerFilterResult>
{
    public Task<SellerFilterResult> Handle(GetSellerByFilterQuery request, CancellationToken cancellationToken)
    {
        var @params = request.FilterParams;
        var query = context.Sellers.OrderByDescending(s => s.CreationTime).AsQueryable();

        if (@params.NationalId != null)
            query = query.Where(s => s.NationalId == @params.NationalId);
        
        if (@params.ShopName != null)
            query = query.Where(s => s.ShopName == @params.ShopName);

        var data = query.Select(s => s.Map()).ToSafePagedList(@params.PageId, @params.Take).ToList();
        
        var result = new SellerFilterResult
        {
            Data = data,
            FilterParams = @params
        };
        
        result.GeneratePaging(query.Count(),  @params.Take, @params.PageId);
        
        return Task.FromResult(result);
    }
}
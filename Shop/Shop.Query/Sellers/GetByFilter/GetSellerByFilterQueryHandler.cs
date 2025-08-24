using Common.Query;
using Common.Query.Filter;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Sellers.DTOs.Filter;

namespace Shop.Query.Sellers.GetByFilter;

public class GetSellerByFilterQueryHandler(ShopContext context) : IQueryHandler<GetSellerByFilterQuery, SellerFilterResult>
{
    public Task<SellerFilterResult> Handle(GetSellerByFilterQuery request, CancellationToken cancellationToken)
    {
        var filters = request.FilterParams;
        var query = context.Sellers.OrderByDescending(s => s.CreationTime).AsQueryable();

        if (filters.NationalId != null)
            query = query.Where(s => s.NationalId == filters.NationalId);
        
        if (filters.ShopName != null)
            query = query.Where(s => s.ShopName == filters.ShopName);

        var data = query.Select(s => s.Map()).ToSafePagedList(filters.PageId, filters.Take).ToList();
        
        var result = new SellerFilterResult
        {
            Data = data,
            FilterParams = filters
        };
        
        result.GeneratePaging(query.Count(),  filters.Take, filters.PageId);
        
        return Task.FromResult(result);
    }
}
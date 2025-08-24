using Common.Query;
using Common.Query.Filter;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Products.DTOs.Filter;

namespace Shop.Query.Products.GetByFilter;

public class GetProductByFilterQueryHandler(ShopContext context) : IQueryHandler<GetProductByFilterQuery, ProductFilterResult>
{
    public Task<ProductFilterResult> Handle(GetProductByFilterQuery request, CancellationToken cancellationToken)
    {
        var filters = request.FilterParams;
        var query = context.Products.OrderByDescending(p => p.CreationTime).AsQueryable();
        
        if (!string.IsNullOrEmpty(filters.Title))
            query = query.Where(p => p.Title.Contains(filters.Title));
        if (!string.IsNullOrEmpty(filters.Slug))
            query = query.Where(p => p.Slug.ToLower().Contains(filters.Slug.ToLower()));

        var data = query.Select(p => p.MapFilter()).ToSafePagedList(filters.PageId, filters.Take).ToList();
        var result = new ProductFilterResult()
        {
            Data = data,
            FilterParams = filters
        };
        
        result.GeneratePaging(query.Count(), filters.Take, filters.PageId);

        return Task.FromResult(result);
    }
}
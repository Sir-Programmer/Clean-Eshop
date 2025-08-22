using Common.Query;
using Common.Query.Filter;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Products.DTOs.Filter;

namespace Shop.Query.Products.GetByFilter;

public class GetProductByFilterQueryHandler(ShopContext context) : IQueryHandler<GetProductByFilterQuery, ProductFilterResult>
{
    public Task<ProductFilterResult> Handle(GetProductByFilterQuery request, CancellationToken cancellationToken)
    {
        var @params = request.FilterParams;
        var query = context.Products.OrderByDescending(p => p.CreationTime).AsQueryable();
        
        if (!string.IsNullOrEmpty(@params.Title))
            query = query.Where(p => p.Title.Contains(@params.Title));
        if (!string.IsNullOrEmpty(@params.Slug))
            query = query.Where(p => p.Slug.ToLower().Contains(@params.Slug.ToLower()));

        var data = query.Select(p => p.MapFilter()).ToSafePagedList(@params.PageId, @params.Take).ToList();
        var result = new ProductFilterResult()
        {
            Data = data,
            FilterParams = @params
        };
        
        result.GeneratePaging(query.Count(), @params.Take, @params.PageId);

        return Task.FromResult(result);
    }
}
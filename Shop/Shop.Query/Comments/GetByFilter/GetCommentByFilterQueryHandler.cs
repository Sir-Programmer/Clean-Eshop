using Common.Query;
using Common.Query.Filter;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Comments.DTOs.Filter;

namespace Shop.Query.Comments.GetByFilter;

public class GetCommentByFilterQueryHandler(ShopContext context)
    : IQueryHandler<GetCommentByFilterQuery, CommentFilterResult>
{
    public Task<CommentFilterResult> Handle(GetCommentByFilterQuery request, CancellationToken cancellationToken)
    {
        var filters = request.FilterParams;
        var query = context.Comments.OrderByDescending(c => c.CreationTime).AsQueryable();

        if (filters.ProductId != null)
            query = query.Where(c => c.ProductId == filters.ProductId);
        if (filters.UserId != null)
            query = query.Where(c => c.UserId == filters.UserId);
        if (filters.CommentStatus != null)
            query = query.Where(c => c.Status == filters.CommentStatus);
        if (filters.StartDate != null)
            query = query.Where(c => c.CreationTime.Date >= filters.StartDate.Value.Date);
        if (filters.EndDate != null)
            query = query.Where(c => c.CreationTime.Date <= filters.EndDate.Value.Date);
        
        var pagedList = query
            .Select(c => c.Map()).ToSafePagedList(filters.PageId, filters.Take).ToList();

        var result = new CommentFilterResult
        {
            Data = pagedList,
            FilterParams = filters
        };

        result.GeneratePaging(query.Count(), filters.Take, filters.PageId);

        return Task.FromResult(result);
    }
}
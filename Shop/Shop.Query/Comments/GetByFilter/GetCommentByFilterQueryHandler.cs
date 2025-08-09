using Common.Query;
using Common.Query.Filter;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Comments.DTOs;

namespace Shop.Query.Comments.GetByFilter;

public class GetCommentByFilterQueryHandler(ShopContext context)
    : IQueryHandler<GetCommentByFilterQuery, CommentFilterResult>
{
    public Task<CommentFilterResult> Handle(GetCommentByFilterQuery request, CancellationToken cancellationToken)
    {
        var @params = request.FilterParams;
        var query = context.Comments.OrderByDescending(c => c.CreationTime).AsQueryable();

        if (@params.ProductId != null)
            query = query.Where(c => c.ProductId == @params.ProductId);
        if (@params.UserId != null)
            query = query.Where(c => c.UserId == @params.UserId);
        if (@params.CommentStatus != null)
            query = query.Where(c => c.Status == @params.CommentStatus);
        if (@params.StartDate != null)
            query = query.Where(c => c.CreationTime.Date >= @params.StartDate.Value.Date);
        if (@params.EndDate != null)
            query = query.Where(c => c.CreationTime.Date <= @params.EndDate.Value.Date);
        
        var pagedList = query
            .Select(c => c.Map()).ToSafePagedList(@params.PageId, @params.Take).ToList();

        var result = new CommentFilterResult
        {
            Data = pagedList,
            FilterParams = @params
        };

        result.GeneratePaging(query.Count(), @params.Take, @params.PageId);

        return Task.FromResult(result);
    }
}
using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.CommentAgg;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Comments.DTOs;

namespace Shop.Query.Comments.GetByFilter;

public class GetCommentByFilterQuery(CommentFilterParams filterParams)
    : QueryFilter<CommentFilterResult, CommentFilterParams>(filterParams)
{
}

public class GetCommentByFilterQueryHandler(ShopContext context)
    : IQueryHandler<GetCommentByFilterQuery, CommentFilterResult>
{
    public async Task<CommentFilterResult> Handle(GetCommentByFilterQuery request, CancellationToken cancellationToken)
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

        var result =
            query.ToPagedResult<Comment, CommentDto, CommentFilterParams, CommentFilterResult>(@params, c => c.Map());
        return result;
    }
}
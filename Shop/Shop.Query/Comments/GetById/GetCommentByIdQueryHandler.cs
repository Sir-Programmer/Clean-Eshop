using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Comments.DTOs;

namespace Shop.Query.Comments.GetById;

public class GetCommentByIdQueryHandler(ShopContext context) : IQueryHandler<GetCommentByIdQuery, CommentDto?>
{
    public async Task<CommentDto?> Handle(GetCommentByIdQuery request, CancellationToken cancellationToken)
    {
        var comment = await context.Comments.FirstOrDefaultAsync(c => c.Id == request.CommentId, cancellationToken);
        return comment.MapOrNull();
    }
}
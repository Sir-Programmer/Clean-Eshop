using Microsoft.EntityFrameworkCore;
using Shop.Domain.CommentAgg;
using Shop.Domain.CommentAgg.Repository;
using Shop.Infrastructure._Utilities;

namespace Shop.Infrastructure.Persistent.Ef.CommentAgg;

public class CommentRepository(ShopContext context) : BaseRepository<Comment>(context), ICommentRepository
{
    public async Task DeleteComment(Guid commentId)
    {
        var comment = await Context.Comments.FirstOrDefaultAsync(c => c.Id == commentId);
        if (comment != null)
            Context.Remove(comment);
    }
}
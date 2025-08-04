using Microsoft.EntityFrameworkCore;
using Shop.Domain.CommentAgg;
using Shop.Domain.CommentAgg.Repository;
using Shop.Infrastructure._Utilities;

namespace Shop.Infrastructure.Persistent.Ef.CommentAgg;

public class CommentRepository(ShopContext context) : BaseRepository<Comment>(context), ICommentRepository
{
    public void DeleteComment(Comment comment)
    {
            Context.Remove(comment);
    }
}
using Shop.Domain.CommentAgg;
using Shop.Domain.CommentAgg.Repository;
using Shop.Infrastructure._Utilities;

namespace Shop.Infrastructure.Persistent.Ef.CommentAgg;

public class CommentRepository(ShopContext context) : BaseRepository<Comment>(context), ICommentRepository
{
    public void Delete(Comment comment)
    {
        Context.Remove(comment);
    }
}
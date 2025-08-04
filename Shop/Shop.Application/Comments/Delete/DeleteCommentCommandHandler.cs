using Common.Application;
using Common.Application.OperationResults;
using Common.Application.UnitOfWork;
using Shop.Domain.CommentAgg.Repository;

namespace Shop.Application.Comments.Delete;

public class DeleteCommentCommandHandler(ICommentRepository commentRepository, IUnitOfWork unitOfWork) : IBaseCommandHandler<DeleteCommentCommand>
{
    public async Task<OperationResult> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
    {
        var comment = await commentRepository.GetByIdAsync(request.CommentId);
        if (comment == null)
            return OperationResult.NotFound();
        commentRepository.DeleteComment(comment);
        await unitOfWork.SaveChangesAsync();
        return OperationResult.Success();
    }
}
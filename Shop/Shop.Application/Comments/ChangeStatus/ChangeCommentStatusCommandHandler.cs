using Common.Application;
using Common.Application.OperationResults;
using Common.Application.UnitOfWork;
using Shop.Domain.CommentAgg.Repository;

namespace Shop.Application.Comments.ChangeStatus;

internal class ChangeCommentStatusCommandHandler(ICommentRepository commentRepository, IUnitOfWork unitOfWork) : IBaseCommandHandler<ChangeCommentStatusCommand>
{
    public async Task<OperationResult> Handle(ChangeCommentStatusCommand request, CancellationToken cancellationToken)
    {
        var comment = await commentRepository.GetByIdTrackingAsync(request.CommentId);
        if (comment == null) return OperationResult.NotFound();
        comment.ChangeStatus(request.Status);
        await unitOfWork.SaveChangesAsync();
        return OperationResult.Success();
    }
}
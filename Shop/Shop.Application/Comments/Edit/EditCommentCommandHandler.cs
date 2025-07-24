using Common.Application;
using Common.Application.OperationResults;
using Common.Application.UnitOfWork;
using Shop.Domain.CommentAgg.Repository;

namespace Shop.Application.Comments.Edit;

public class EditCommentCommandHandler(ICommentRepository commentRepository, IUnitOfWork unitOfWork) : IBaseCommandHandler<EditCommentCommand>
{
    public async Task<OperationResult> Handle(EditCommentCommand request, CancellationToken cancellationToken)
    {
        var comment = await commentRepository.GetByIdTrackingAsync(request.Id);
        if (comment == null || comment.UserId != request.UserId) return OperationResult.NotFound();
        comment.Edit(request.Text);
        await unitOfWork.SaveChangesAsync();
        return OperationResult.Success();
    }
}
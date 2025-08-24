using Common.Application.OperationResults;
using Shop.Application.Comments.ChangeStatus;
using Shop.Application.Comments.Create;
using Shop.Application.Comments.Delete;
using Shop.Application.Comments.Edit;
using Shop.Query.Comments.DTOs;
using Shop.Query.Comments.DTOs.Filter;

namespace Shop.Presentation.Facade.Comments;

public interface ICommentFacade
{
    Task<OperationResult<Guid>> Create(CreateCommentCommand command);
    Task<OperationResult> Delete(DeleteCommentCommand command);
    Task<OperationResult> Edit(EditCommentCommand command);
    Task<OperationResult> ChangeStatus(ChangeCommentStatusCommand command);

    Task<CommentDto?> GetById(Guid id);
    Task<CommentFilterResult> GetByFilter(CommentFilterParams filters);
}
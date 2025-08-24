using Common.Application.OperationResults;
using MediatR;
using Shop.Application.Comments.ChangeStatus;
using Shop.Application.Comments.Create;
using Shop.Application.Comments.Delete;
using Shop.Application.Comments.Edit;
using Shop.Query.Comments.DTOs;
using Shop.Query.Comments.DTOs.Filter;
using Shop.Query.Comments.GetByFilter;
using Shop.Query.Comments.GetById;

namespace Shop.Presentation.Facade.Comments;

public class CommentFacade(IMediator mediator) : ICommentFacade
{
    public async Task<OperationResult<Guid>> Create(CreateCommentCommand command)
    {
        return await mediator.Send(command);
    }

    public async Task<OperationResult> Delete(DeleteCommentCommand command)
    {
        return await mediator.Send(command);
    }

    public async Task<OperationResult> Edit(EditCommentCommand command)
    {
        return await mediator.Send(command);
    }

    public async Task<OperationResult> ChangeStatus(ChangeCommentStatusCommand command)
    {
        return await mediator.Send(command);
    }

    public async Task<CommentDto?> GetById(Guid id)
    {
        return await mediator.Send(new GetCommentByIdQuery(id));
    }

    public async Task<CommentFilterResult> GetByFilter(CommentFilterParams filters)
    {
        return await mediator.Send(new GetCommentByFilterQuery(filters));
    }
}
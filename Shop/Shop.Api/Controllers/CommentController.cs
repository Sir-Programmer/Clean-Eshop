using Common.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.ViewModels.Comment;
using Shop.Application.Comments.ChangeStatus;
using Shop.Application.Comments.Create;
using Shop.Application.Comments.Edit;
using Shop.Presentation.Facade.Comments;
using Shop.Query.Comments.DTOs;
using Shop.Query.Comments.DTOs.Filter;

namespace Shop.Api.Controllers;

[Authorize]
public class CommentController(ICommentFacade commentFacade) : ApiController
{
    [HttpGet]
    public async Task<ApiResult<CommentFilterResult?>> GetCommentsByFilter([FromQuery] CommentFilterParams filters)
    {
        return QueryResult(await commentFacade.GetByFilter(filters));
    }

    [HttpGet("{id:guid}")]
    public async Task<ApiResult<CommentDto?>> GetComment(Guid id)
    {
        return QueryResult(await commentFacade.GetById(id));
    }
    
    [HttpPost]
    public async Task<ApiResult<Guid>> CreateComment(CreateCommentCommand command)
    {
        return CommandResult(await commentFacade.Create(command));
    }
    
    [HttpPut("{id:guid}")]
    public async Task<ApiResult> EditComment(Guid id, EditCommentViewModel vm)
    {
        var userId = User.GetUserId();
        return CommandResult(await commentFacade.Edit(new EditCommentCommand(id, vm.Text, userId)));
    }
    
    [HttpPut("{id:guid}/status")]
    public async Task<ApiResult> ChangeCommentStatus(Guid id, ChangeCommentStatusViewModel vm)
    {
        return CommandResult(await commentFacade.ChangeStatus(new ChangeCommentStatusCommand(id, vm.Status)));
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<ApiResult> DeleteComment(Guid id)
    {
        return CommandResult(await commentFacade.Delete(id));
    }
}
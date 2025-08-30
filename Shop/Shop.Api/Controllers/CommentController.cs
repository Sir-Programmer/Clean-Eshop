using Common.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Comments.ChangeStatus;
using Shop.Application.Comments.Create;
using Shop.Application.Comments.Edit;
using Shop.Presentation.Facade.Comments;
using Shop.Query.Comments.DTOs;
using Shop.Query.Comments.DTOs.Filter;

namespace Shop.Api.Controllers;

public class CommentController(ICommentFacade commentFacade) : ApiController
{
    [HttpGet]
    public async Task<ApiResult<CommentFilterResult?>> GetCommentsByFilter([FromQuery] CommentFilterParams filters)
    {
        return QueryResult(await commentFacade.GetByFilter(filters));
    }

    [HttpGet("{commentId:guid}")]
    public async Task<ApiResult<CommentDto?>> GetComment(Guid commentId)
    {
        return QueryResult(await commentFacade.GetById(commentId));
    }
    
    [HttpPost]
    public async Task<ApiResult<Guid>> CreateComment(CreateCommentCommand command)
    {
        return CommandResult(await commentFacade.Create(command));
    }
    
    [HttpPut]
    public async Task<ApiResult> EditComment(EditCommentCommand command)
    {
        return CommandResult(await commentFacade.Edit(command));
    }
    
    [HttpPut("ChangeStatus")]
    public async Task<ApiResult> ChangeCommentStatus(ChangeCommentStatusCommand command)
    {
        return CommandResult(await commentFacade.ChangeStatus(command));
    }
    
    [HttpDelete("{commentId:guid}")]
    public async Task<ApiResult> DeleteComment(Guid commentId)
    {
        return CommandResult(await commentFacade.Delete(commentId));
    }
}
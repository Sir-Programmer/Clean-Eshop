using Common.Application;

namespace Shop.Application.Comments.Delete;

public record DeleteCommentCommand(Guid CommentId) : IBaseCommand;
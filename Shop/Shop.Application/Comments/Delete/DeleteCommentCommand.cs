using Common.Application;
using FluentValidation;

namespace Shop.Application.Comments.Delete;

public record DeleteCommentCommand(Guid CommentId) : IBaseCommand;
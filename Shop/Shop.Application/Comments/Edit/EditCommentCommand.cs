using Common.Application;

namespace Shop.Application.Comments.Edit;

public record EditCommentCommand(Guid Id, string Text, Guid UserId) : IBaseCommand;
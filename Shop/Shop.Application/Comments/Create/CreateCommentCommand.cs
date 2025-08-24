using Common.Application;

namespace Shop.Application.Comments.Create;

public record CreateCommentCommand(Guid UserId, Guid ProductId, string Text) : IBaseCommand<Guid>;
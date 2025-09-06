using Common.Application;

namespace Shop.Application.Users.DeleteToken;

public record DeleteTokenCommand(Guid UserId, Guid TokenId) : IBaseCommand;
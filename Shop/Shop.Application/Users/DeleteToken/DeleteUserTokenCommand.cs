using Common.Application;

namespace Shop.Application.Users.DeleteToken;

public record DeleteUserTokenCommand(Guid UserId, Guid TokenId) : IBaseCommand;
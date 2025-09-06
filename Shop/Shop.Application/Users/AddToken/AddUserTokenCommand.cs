using Common.Application;

namespace Shop.Application.Users.AddToken;

public record AddUserTokenCommand(Guid UserId, string TokenHash, string RefreshTokenHash, DateTime TokenExpireDate, DateTime RefreshTokenExpireDate, string Device) : IBaseCommand;
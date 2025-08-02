using Common.Application;

namespace Shop.Application.Users.ChangePassword;

public record ChangeUserPasswordCommand(Guid UserId, string CurrentPassword, string Password) : IBaseCommand;
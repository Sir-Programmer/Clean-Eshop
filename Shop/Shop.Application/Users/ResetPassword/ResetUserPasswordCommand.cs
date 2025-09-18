using Common.Application;

namespace Shop.Application.Users.ResetPassword;

public record ResetUserPasswordCommand(Guid UserId, string NewPassword) : IBaseCommand;
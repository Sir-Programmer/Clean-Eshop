using Common.Application;

namespace Shop.Application.Users.ResetPassword;

public record ResetPasswordCommand(Guid UserId, string NewPassword) : IBaseCommand;
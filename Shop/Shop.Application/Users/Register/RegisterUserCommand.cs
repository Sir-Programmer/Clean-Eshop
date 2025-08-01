using Common.Application;

namespace Shop.Application.Users.Register;

public record RegisterUserCommand(string PhoneNumber, string Password) : IBaseCommand;
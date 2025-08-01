using Common.Application;
using Shop.Domain.UserAgg.Enums;

namespace Shop.Application.Users.Edit;

public record EditUserCommand(Guid UserId, string Name, string Family, string PhoneNumber, string Email, Gender Gender) : IBaseCommand;
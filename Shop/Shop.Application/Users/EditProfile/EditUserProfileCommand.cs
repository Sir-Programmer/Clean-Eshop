using Common.Application;
using Shop.Domain.UserAgg.Enums;

namespace Shop.Application.Users.EditProfile;

public record EditUserProfileCommand(Guid UserId, string Name, string Family, Gender Gender) : IBaseCommand;
using Shop.Domain.UserAgg;
using Shop.Query.Users.DTOs;

namespace Shop.Query.Users;

public static class UserMapper
{
    public static UserDto? Map(this User? user, List<UserRoleDto> userRoles)
    {
        if  (user == null) return null;
        return new UserDto()
        {
            Id = user.Id,
            CreationTime = user.CreationTime,
            Name = user.Name,
            Family = user.Family,
            Email = user.Email,
            PhoneNumber = user.PhoneNumber,
            Gender = user.Gender,
            Roles = userRoles
        };
    }
}
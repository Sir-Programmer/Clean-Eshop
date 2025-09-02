using Shop.Domain.UserAgg;
using Shop.Query.Users.DTOs;
using Shop.Query.Users.DTOs.Filter;

namespace Shop.Query.Users;

public static class UserMapper
{
    public static UserDto? MapOrNull(this User? user, List<UserRoleDto> userRoles)
    {
        return user?.Map(userRoles);
    }
    
    public static UserDto Map(this User user, List<UserRoleDto> userRoles)
    {
        return new UserDto
        {
            Id = user.Id,
            CreationTime = user.CreationTime,
            Name = user.Name,
            Family = user.Family,
            Email = user.Email,
            Password = user.Password,
            PhoneNumber = user.PhoneNumber,
            Gender = user.Gender,
            Roles = userRoles
        };
    }
    
    public static UserFilterDto MapFilter(this User user)
    {
        return new UserFilterDto
        {
            Id = user.Id,
            CreationTime = user.CreationTime,
            Name = user.Name,
            Family = user.Family,
            Email = user.Email,
            PhoneNumber = user.PhoneNumber,
            Gender = user.Gender,
        };
    }
}
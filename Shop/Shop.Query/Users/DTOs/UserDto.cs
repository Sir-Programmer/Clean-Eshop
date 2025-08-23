using Shop.Domain.UserAgg.Enums;

namespace Shop.Query.Users.DTOs;

public class UserDto
{
    public string Name { get; set; }
    public string Family { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public Gender Gender { get; set; }

    public List<UserRoleDto> Roles { get; set; }
}
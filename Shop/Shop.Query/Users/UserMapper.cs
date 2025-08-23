using Shop.Domain.UserAgg;
using Shop.Query.Users.DTOs;

namespace Shop.Query.Users;

public static class UserMapper
{
    public static UserDto? Map(this User? user)
    {
        if  (user == null) return null;
        return new UserDto()
        {

        };
    }
}
using Shop.Query.Users.DTOs;

namespace Shop.Query.Users.Services;

public interface IUserQueryService
{
    Task<List<UserRoleDto>> GetRolesDataAsync(List<Guid> roleIds);
}
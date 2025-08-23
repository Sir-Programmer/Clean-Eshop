using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Users.DTOs;

namespace Shop.Query.Users.Services;

public class UserQueryService(ShopContext context) : IUserQueryService
{
    public async Task<List<UserRoleDto>> GetRolesDataAsync(List<Guid> roleIds)
    {
        return await context.Roles
            .Where(r => roleIds.Contains(r.Id))
            .Select(r => new UserRoleDto
            {
                RoleId = r.Id,
                RoleTitle = r.Title
            })
            .ToListAsync();
    }
}
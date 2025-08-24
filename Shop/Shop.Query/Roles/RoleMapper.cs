using Shop.Domain.RoleAgg;
using Shop.Domain.RoleAgg.Enums;
using Shop.Query.Roles.DTOs;

namespace Shop.Query.Roles;

public static class RoleMapper
{
    public static RoleDto? MapOrNull(this Role? role)
    {
        return role?.Map();
    }
    
    public static RoleDto Map(this Role role)
    {
        return new RoleDto
        {
            Id = role.Id,
            CreationTime = role.CreationTime,
            Title = role.Title,
            Permissions = role.Permissions.Select(r => r.Permission).ToList()
        };
    }
}
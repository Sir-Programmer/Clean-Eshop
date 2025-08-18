using Shop.Domain.RoleAgg.Enums;

namespace Shop.Query.Roles.DTOs;

public class RoleDto
{
    public string Title { get; set; }
    public List<Permission> Permissions { get; set; }
}
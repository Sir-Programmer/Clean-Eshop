using Shop.Domain.RoleAgg.Enums;

namespace Shop.Api.ViewModels.Role;

public class EditRoleViewModel
{
    public string Title { get; set; }
    public List<Permission> Permissions { get; set; }
}
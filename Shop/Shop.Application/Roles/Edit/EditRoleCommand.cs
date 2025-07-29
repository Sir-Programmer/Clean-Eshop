using Common.Application;
using Shop.Domain.RoleAgg.Enums;

namespace Shop.Application.Roles.Edit;

public record EditRoleCommand(Guid RoleId, string Title, List<Permission> Permissions) : IBaseCommand;
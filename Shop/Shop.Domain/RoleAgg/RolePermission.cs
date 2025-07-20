using Common.Domain;
using Shop.Domain.RoleAgg.Enums;

namespace Shop.Domain.RoleAgg;

public class RolePermission(Permission permission) : BaseEntity
{
    public Guid RoleId { get; internal set; }
    public Permission Permission { get; private set; } = permission;
}
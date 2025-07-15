using Common.Domain;

namespace Shop.Domain.UserAgg;

public class UserRole(Guid roleId) : BaseEntity
{
    public Guid UserId { get; internal set; }
    public Guid RoleId { get; private set; } = roleId;
}
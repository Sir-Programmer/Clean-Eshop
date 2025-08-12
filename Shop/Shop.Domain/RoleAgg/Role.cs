using Common.Domain;
using Common.Domain.Exceptions;

namespace Shop.Domain.RoleAgg;

public class Role : AggregateRoot
{
    private Role()
    {
        
    }
    public Role(string title)
    {
        Guard(title);
        Title = title;
        Permissions = [];
    }
    public string Title { get; private set; }
    public List<RolePermission> Permissions { get; private set; }

    public void Edit(string title)
    {
        Guard(title);
        Title = title;
    }

    public void SetPermissions(List<RolePermission> permissions)
    {
        Permissions = permissions;
    }

    private void Guard(string title)
    {
        NullOrEmptyDomainException.CheckString(title, nameof(title));
    }
}
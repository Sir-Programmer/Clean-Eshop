using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Roles.DTOs;

namespace Shop.Query.Roles.GetList;

public class GetRoleListQueryHandler(ShopContext context) : IQueryHandler<GetRoleListQuery, List<RoleDto?>>
{
    public async Task<List<RoleDto?>> Handle(GetRoleListQuery request, CancellationToken cancellationToken)
    {
        return await context.Roles.Select(r => r.Map()).ToListAsync(cancellationToken);
    }
}
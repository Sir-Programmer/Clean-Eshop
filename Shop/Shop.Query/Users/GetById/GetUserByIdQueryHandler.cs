using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Users.DTOs;
using Shop.Query.Users.Services;

namespace Shop.Query.Users.GetById;

public class GetUserByIdQueryHandler(ShopContext context, IUserQueryService userQueryService) : IQueryHandler<GetUserByIdQuery, UserDto?>
{
    public async Task<UserDto?> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await context.Users.Include(u => u.Roles).SingleOrDefaultAsync(u => u.Id == request.UserId, cancellationToken);
        if (user == null) return null;
        var userRoles = await userQueryService.GetRolesDataAsync(user.Roles.Select(r => r.RoleId).ToList());
        return user.MapOrNull(userRoles);
    }
}
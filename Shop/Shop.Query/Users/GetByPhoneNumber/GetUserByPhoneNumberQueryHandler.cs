using Common.Query;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Persistent.Ef;
using Shop.Query.Users.DTOs;
using Shop.Query.Users.Services;

namespace Shop.Query.Users.GetByPhoneNumber;

public class GetUserByPhoneNumberQueryHandler(ShopContext context, IUserQueryService userQueryService) : IQueryHandler<GetUserByPhoneNumberQuery, UserDto?>
{
    public async Task<UserDto?> Handle(GetUserByPhoneNumberQuery request, CancellationToken cancellationToken)
    {
        var user = await context.Users.Include(u => u.Roles).SingleOrDefaultAsync(u => u.PhoneNumber == request.PhoneNumber, cancellationToken);
        if (user == null) return null;
        var userRoles = await userQueryService.GetRolesDataAsync(user.Roles.Select(r => r.RoleId).ToList());
        return user.MapOrNull(userRoles);
    }
}
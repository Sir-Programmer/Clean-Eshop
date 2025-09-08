using Common.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Shop.Domain.RoleAgg.Enums;
using Shop.Presentation.Facade.Roles;
using Shop.Presentation.Facade.Users;

namespace Shop.Api.Infrastructure.Security;

public class PermissionChecker(Permission permission) : AuthorizeAttribute, IAsyncAuthorizationFilter
{
    public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
    {
        if (context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any())
            return;

        var userFacade = context.HttpContext.RequestServices.GetRequiredService<IUserFacade>();
        var roleFacade = context.HttpContext.RequestServices.GetRequiredService<IRoleFacade>();

        if (!context.HttpContext.User.Identity?.IsAuthenticated ?? true)
        {
            context.Result = new UnauthorizedObjectResult("Unauthorize");
            return;
        }

        var user = await userFacade.GetById(context.HttpContext.User.GetUserId());
        if (user == null)
        {
            context.Result = new ForbidResult();
            return;
        }

        var roles = await roleFacade.GetAll();
        var hasPermission = roles
            .Where(r => user.Roles.Any(ur => ur.RoleId == r.Id))
            .Any(r => r.Permissions.Contains(permission));

        if (!hasPermission)
            context.Result = new ForbidResult();
    }
}
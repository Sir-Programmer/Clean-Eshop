using Microsoft.AspNetCore.Authentication.JwtBearer;
using Shop.Presentation.Facade.Users;

namespace Shop.Api.Infrastructure.JwtUtils;

public class CustomJwtValidation(IUserFacade userFacade)
{
    public async Task Validate(TokenValidatedContext context)
    {
        var jwtToken = context.Request.Headers.Authorization.ToString().Replace("Bearer ", "");
        var token = await userFacade.GetByJwtToken(jwtToken);
        if (token == null)
        {
            context.Fail("Invalid Token");
        }
    }
}
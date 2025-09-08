using System.Security.Claims;

namespace Common.AspNetCore;

public static class ClaimUtils
{
    public static Guid? GetUserId(this ClaimsPrincipal principal)
    {
        return Guid.TryParse(principal?.FindFirst(ClaimTypes.NameIdentifier)?.Value, out var id) ? id : null;
    }

    public static string? GetPhoneNumber(this ClaimsPrincipal principal)
    {
        return principal?.FindFirst(ClaimTypes.MobilePhone)?.Value;
    }
}
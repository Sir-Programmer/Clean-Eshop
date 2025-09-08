using System.Security.Claims;

namespace Common.AspNetCore;

public static class ClaimUtils
{
    public static Guid GetUserId(this ClaimsPrincipal principal)
    {
        ArgumentNullException.ThrowIfNull(principal);

        var value = principal.FindFirst(ClaimTypes.NameIdentifier)?.Value 
                    ?? throw new ArgumentNullException(nameof(ClaimTypes.NameIdentifier));

        return Guid.Parse(value);
    }

    public static string GetPhoneNumber(this ClaimsPrincipal principal)
    {
        ArgumentNullException.ThrowIfNull(principal);

        return principal.FindFirst(ClaimTypes.MobilePhone)?.Value
               ?? throw new ArgumentNullException(nameof(ClaimTypes.MobilePhone));
    }
}

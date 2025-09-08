using Common.Query;

namespace Shop.Query.Users.DTOs;

public class UserTokenDto : BaseDto
{
    public Guid UserId { get; set; }
    public string TokenHash { get; set; }
    public string RefreshTokenHash { get; set; }
    public DateTime TokenExpireDate { get; set; }
    public DateTime RefreshTokenExpireDate { get; set; }
    public string Device { get; set; }
}
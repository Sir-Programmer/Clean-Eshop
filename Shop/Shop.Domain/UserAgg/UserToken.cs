using Common.Domain;
using Common.Domain.Exceptions;

namespace Shop.Domain.UserAgg;

public class UserToken : BaseEntity
{
    private UserToken()
    {
        
    }
    public UserToken(string tokenHash, string refreshTokenHash, DateTime tokenExpireDate, DateTime refreshTokenExpireDate, string device)
    {
        Guard(tokenHash, refreshTokenHash, device, tokenExpireDate, refreshTokenExpireDate);
        TokenHash = tokenHash;
        RefreshTokenHash = refreshTokenHash;
        TokenExpireDate = tokenExpireDate;
        RefreshTokenExpireDate = refreshTokenExpireDate;
        Device = device;
    }
    public Guid UserId { get; internal set; }
    public string TokenHash { get; private set; }
    public string RefreshTokenHash { get; private set; }
    public DateTime TokenExpireDate { get; private set; }
    public DateTime RefreshTokenExpireDate { get; private set; }
    public string Device { get; private set; }

    private void Guard(string tokenHash, string refreshTokenHash, string device, DateTime tokenExpireDate, DateTime refreshTokenExpireDate)
    {
        NullOrEmptyDomainException.CheckString(tokenHash, nameof(tokenHash));
        NullOrEmptyDomainException.CheckString(refreshTokenHash, nameof(refreshTokenHash));
        NullOrEmptyDomainException.CheckString(device, nameof(device));
        
        if (tokenExpireDate < DateTime.Now)
            throw new InvalidDomainDataException("Invalid token expire date");
        if  (refreshTokenExpireDate < tokenExpireDate)
            throw new InvalidDomainDataException("Invalid refresh token expire date");
    }
}
using Common.Query;
using Shop.Query.Users.DTOs;

namespace Shop.Query.Users.UserTokens.GetByJwtToken;

public record GetUserTokenByJwtTokenQuery(string JwtToken) : IQuery<UserTokenDto?>;
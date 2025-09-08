using Common.Query;
using Dapper;
using Shop.Infrastructure.Persistent.Dapper;
using Shop.Query.Users.DTOs;

namespace Shop.Query.Users.UserTokens.GetByRefreshToken;

public class GetUserTokenByRefreshTokenQueryHandler(DapperContext dapperContext) :  IQueryHandler<GetUserTokenByRefreshTokenQuery, UserTokenDto?>
{
    public async Task<UserTokenDto?> Handle(GetUserTokenByRefreshTokenQuery request, CancellationToken cancellationToken)
    {
        var connection = dapperContext.CreateConnection();
        const string sql = $"SELECT TOP(1) * FROM {DapperContext.UserTokens} WHERE RefreshTokenHash = @refreshToken";
        return await connection.QueryFirstOrDefaultAsync<UserTokenDto>(sql, new { request.RefreshToken });
    }
}
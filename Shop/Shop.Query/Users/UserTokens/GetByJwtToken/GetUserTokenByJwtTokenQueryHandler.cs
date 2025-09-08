using Common.Query;
using Dapper;
using Shop.Infrastructure.Persistent.Dapper;
using Shop.Query.Users.DTOs;

namespace Shop.Query.Users.UserTokens.GetByJwtToken;

public class GetUserTokenByJwtTokenQueryHandler(DapperContext dapperContext) :  IQueryHandler<GetUserTokenByJwtTokenQuery, UserTokenDto?>
{
    public async Task<UserTokenDto?> Handle(GetUserTokenByJwtTokenQuery request, CancellationToken cancellationToken)
    {
        var connection = dapperContext.CreateConnection();
        const string sql = $"SELECT TOP(1) * FROM {DapperContext.UserTokens} WHERE TokenHash = @JwtToken";
        return await connection.QueryFirstOrDefaultAsync<UserTokenDto>(sql, new { request.JwtToken });
    }
}
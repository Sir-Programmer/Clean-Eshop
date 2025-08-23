using Common.Query;
using Dapper;
using Shop.Infrastructure.Persistent.Dapper;
using Shop.Query.Users.DTOs;

namespace Shop.Query.Users.Addresses.GetList;

public class GetUserAddressListQueryHandler(DapperContext dapperContext) : IQueryHandler<GetUserAddressListQuery, List<UserAddressDto>>
{
    public async Task<List<UserAddressDto>> Handle(GetUserAddressListQuery request, CancellationToken cancellationToken)
    {
        using var connection = dapperContext.CreateConnection();
        const string sql = $"SELECT * FROM {DapperContext.UserAddresses} WHERE UserId = @userId";
        var addresses = await connection.QueryAsync<UserAddressDto>(sql, new { request.UserId });
        return addresses.ToList();
    }
}
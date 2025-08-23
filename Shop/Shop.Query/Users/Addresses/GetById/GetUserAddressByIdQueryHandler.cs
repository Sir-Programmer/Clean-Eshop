using Common.Query;
using Dapper;
using Shop.Infrastructure.Persistent.Dapper;
using Shop.Query.Users.DTOs;

namespace Shop.Query.Users.Addresses.GetById;

public class GetUserAddressByIdQueryHandler(DapperContext dapperContext) :  IQueryHandler<GetUserAddressByIdQuery, UserAddressDto?>
{
    public async Task<UserAddressDto?> Handle(GetUserAddressByIdQuery request, CancellationToken cancellationToken)
    {
        using var connection = dapperContext.CreateConnection();
        const string sql = $"SELECT Top(1) * FROM {DapperContext.UserAddresses} WHERE Id = @Id";
        return await connection.QuerySingleOrDefaultAsync<UserAddressDto?>(sql, new { Id = request.AddressId });
    }
}
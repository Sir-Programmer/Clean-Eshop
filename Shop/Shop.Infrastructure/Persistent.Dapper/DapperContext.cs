using System.Data;
using Microsoft.Data.SqlClient;

namespace Shop.Infrastructure.Persistent.Dapper;

public class DapperContext(string connectionString)
{
    public IDbConnection CreateConnection() => new SqlConnection(connectionString);

    public const string Inventories = "[seller].Inventories";
    public const string UserAddresses = "[user].Addresses";
    public const string UserTokens = "[user].Tokens";
    public const string OrderItems = "[order].Items";
    public const string Products = "[product].Products";
    public const string ProductSubCategories = "[product].SubCategories";
    public const string Sellers = "[seller].Sellers";
}
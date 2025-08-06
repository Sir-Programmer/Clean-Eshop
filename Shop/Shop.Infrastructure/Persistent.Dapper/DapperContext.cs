using System.Data;
using Microsoft.Data.SqlClient;

namespace Shop.Infrastructure.Persistent.Dapper;

public class DapperContext(string connectionString)
{
    public IDbConnection CreateConnection => new SqlConnection(connectionString);

    public const string Inventories = "[seller].Inventories";
}
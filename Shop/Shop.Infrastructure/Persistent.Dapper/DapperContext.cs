using System.Data;
using Microsoft.Data.SqlClient;

namespace Shop.Infrastructure.Persistent.Dapper;

public class DapperContext(string connectionString)
{
    public IDbConnection Connection => new SqlConnection(connectionString);
    
    public string Inventories = "[seller].Inventories";
}
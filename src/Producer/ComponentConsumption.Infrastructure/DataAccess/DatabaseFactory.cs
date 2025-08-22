using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace ComponentConsumption.Infrastructure.DataAccess
{
    public class DatabaseFactory(IConfiguration configuration)
    {
        public IDbConnection CreateConnection()
        {
            var connectionString = configuration.GetConnectionString("ConnectionSQLServer");
            return new SqlConnection(connectionString);
        }
    }
}

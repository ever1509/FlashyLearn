using System.Data;
using System.Data.Common;
using Application.Common.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Data.PostgresSQL.Factories;

public class ConnectionFactory : IConnectionFactory
{
    private readonly string connectionString;
    public ConnectionFactory(IConfiguration configuration)
    {
        connectionString = configuration.GetConnectionString("FlashyConnPostgresSQL") ?? string.Empty;
    }

    public IDbConnection GetConnection
    {
        get
        {
            var factory = DbProviderFactories.GetFactory("System.Data.SqlClient");  
            var conn = factory.CreateConnection();  
            conn.ConnectionString = connectionString;  
            conn.Open();  
            return conn;  
        }
    }
}
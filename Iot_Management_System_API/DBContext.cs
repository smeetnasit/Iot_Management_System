using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Iot_Management_System_API
{
    public class DBContext
    {
        private readonly IConfiguration configuration;
        private readonly string _connectionString;


        public DBContext(IConfiguration _configuration)
        {
            _configuration = _configuration;
            _connectionString = _configuration.GetConnectionString("DataConnection");

        }
        public IDbConnection CreateConnection()
           => new SqlConnection(_connectionString);


    }
}

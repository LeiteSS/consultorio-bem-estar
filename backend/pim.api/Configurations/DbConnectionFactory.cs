using Microsoft.Extensions.Configuration;
using System;

using System.Data.Odbc;
using System.Linq;
using System.Threading.Tasks;

namespace pim.api.Configurations
{
    static class DbConnectionFactory
    {
        public static OdbcConnection CreateConnection()
        {
            var configuration = new ConfigurationBuilder()
                                   .AddJsonFile("apisettings.json")
                                   .Build();

            String connectionString = configuration.GetConnectionString("OdbcConnString");

            return new OdbcConnection(connectionString);
        }
    }
}

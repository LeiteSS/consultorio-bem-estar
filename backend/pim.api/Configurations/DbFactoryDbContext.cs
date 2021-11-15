using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using pim.api.Infraestruture.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pim.api.Configurations
{
    public class DbFactoryDbContext : IDesignTimeDbContextFactory<ConsultasDbContext>
    {
        public ConsultasDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                                    .AddJsonFile("apisettings.json")
                                    .Build();

            var optionsBuilder = new DbContextOptionsBuilder<ConsultasDbContext>();
            optionsBuilder.UseMySql(configuration.GetConnectionString("DefaultConnection"), new MariaDbServerVersion(new Version(10, 3, 29)));
            ConsultasDbContext contexto = new ConsultasDbContext(optionsBuilder.Options);
            return contexto;
        }
    }
}

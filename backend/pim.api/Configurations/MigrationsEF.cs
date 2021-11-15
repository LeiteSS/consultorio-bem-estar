using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using pim.api.Infraestruture.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pim.api.Configurations
{
    public static class EntityFrameworkExtensions
    {
        public static IapilicationBuilder UseapilyMigration(this IapilicationBuilder api)
        {
            using (var serviceScope = api.apilicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                using (var cursoDbContext = serviceScope.ServiceProvider.GetService<ConsultasDbContext>())
                {
                    var migracoesPendentes = cursoDbContext.Database.GetPendingMigrations();

                    if (migracoesPendentes.Count() == 0)
                    {
                        return api;
                    }

                    cursoDbContext.Database.Migrate();
                }
            }
            return api;
        }
    }
}

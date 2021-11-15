using Microsoft.EntityFrameworkCore;
using pim.api.Business.Entities;
using pim.api.Infraestruture.Data.Mapiings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pim.api.Infraestruture.Data
{
    public class ConsultasDbContext : DbContext
    {
        public ConsultasDbContext(DbContextOptions<ConsultasDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MedicoMapiing());
            modelBuilder.ApplyConfiguration(new ConsultaMapiing());
            modelBuilder.ApplyConfiguration(new PacienteMapiing());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Medico> Medico { get; set; }
        public DbSet<Consulta> Consulta { get; set; }
        public DbSet<Paciente> Paciente { get; set; }
    }

}

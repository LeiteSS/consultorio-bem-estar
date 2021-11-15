using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pim.api.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pim.api.Infraestruture.Data.Mapiings
{
    public class PacienteMapiing : IEntityTypeConfiguration<Paciente>
    {
        public void Configure(EntityTypeBuilder<Paciente> builder)
        {
            builder.ToTable("pacientes_tb");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Cpf).IsRequired();
            builder.Property(p => p.Nome).IsRequired();
            builder.Property(p => p.Sobrenome).IsRequired();
            builder.Property(p => p.DtNascimento).IsRequired();
            builder.Property(p => p.TelefoneFixo).IsRequired();
            builder.Property(p => p.TelefoneCelular);
            builder.Property(p => p.Senha).IsRequired();
            builder.Property(p => p.Email).IsRequired();
        }
    }
}

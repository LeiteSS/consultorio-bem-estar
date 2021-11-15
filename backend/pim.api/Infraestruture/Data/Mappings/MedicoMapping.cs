using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pim.api.Business.Entities;

namespace pim.api.Infraestruture.Data.Mapiings
{
    public class MedicoMapiing : IEntityTypeConfiguration<Medico>
    {
        public void Configure(EntityTypeBuilder<Medico> builder)
        {
            builder.ToTable("medicos_tb");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Nome).IsRequired();
            builder.Property(p => p.Sobrenome).IsRequired();
            builder.Property(p => p.DtNascimento).IsRequired();
            builder.Property(p => p.TelefoneFixo).IsRequired();
            builder.Property(p => p.TelefoneCelular);
            builder.Property(p => p.Especialidade).IsRequired();
            builder.Property(p => p.Crm).IsRequired();
            builder.Property(p => p.Senha).IsRequired();
            builder.Property(p => p.Email).IsRequired();
        }
    }
}
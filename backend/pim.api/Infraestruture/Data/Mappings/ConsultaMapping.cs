using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pim.api.Business.Entities;

namespace pim.api.Infraestruture.Data.Mapiings
{
    internal class ConsultaMapiing : IEntityTypeConfiguration<Consulta>
    {
        public void Configure(EntityTypeBuilder<Consulta> builder)
        {
            builder.ToTable("consultas_tb");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Descricao).IsRequired();
            builder.Property(p => p.Anexo).IsRequired();
            builder.Property(p => p.DtHora).IsRequired();
            builder.Property(p => p.Status).IsRequired();
            builder.Property(p => p.TransacaoID).IsRequired();
            builder.HasOne(p => p.Paciente)
                .WithMany().HasForeignKey(fk => fk.PacienteId);
        }
    }
}
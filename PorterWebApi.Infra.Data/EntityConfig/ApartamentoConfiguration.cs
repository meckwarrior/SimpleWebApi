using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PorterWebApi.Domain.Entities;

namespace PorterWebApi.Infra.Data.EntityConfig
{
    public class ApartamentoConfiguration : IEntityTypeConfiguration<Apartamento>
    {
        public void Configure(EntityTypeBuilder<Apartamento> builder)
        {
            builder.HasKey(p => p.ApartamentoId);

            builder.HasIndex(p => new { p.Numero, p.BlocoId })
                .IsUnique();

            builder.HasOne<Bloco>()
                .WithMany()
                .HasForeignKey(p => p.BlocoId);
        }
    }
}

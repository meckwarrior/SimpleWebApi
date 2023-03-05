using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PorterWebApi.Domain.Entities;

namespace PorterWebApi.Infra.Data.EntityConfig
{
    public class BlocoConfiguration : IEntityTypeConfiguration<Bloco>
    {
        public void Configure(EntityTypeBuilder<Bloco> builder)
        {
            builder.HasIndex(p => new { p.Nome, p.CondominioId })
                .IsUnique();

            builder.Property(p => p.Nome)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.HasOne<Condominio>()
                    .WithMany()
                    .HasForeignKey(p => p.CondominioId);
        }
    }
}

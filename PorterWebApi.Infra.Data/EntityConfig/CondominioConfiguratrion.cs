using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PorterWebApi.Domain.Entities;

namespace PorterWebApi.Infra.Data.EntityConfig
{
    public class CondominioConfiguration : IEntityTypeConfiguration<Condominio>
    {
        public void Configure(EntityTypeBuilder<Condominio> builder)
        {
            builder.HasKey(p => p.CondominioId);

            builder.Property(p => p.Nome)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(p => p.EmailSindico)
                .HasColumnType("varchar(50)")
               .IsRequired();

            builder.Property(p => p.TelefoneSindico)
                .HasColumnType("varchar(20)")
               .IsRequired();

        }
    }
}

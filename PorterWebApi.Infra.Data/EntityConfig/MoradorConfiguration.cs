using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PorterWebApi.Domain.Entities;

namespace PorterWebApi.Infra.Data.EntityConfig
{
    public class MoradorConfiguration : IEntityTypeConfiguration<Morador>
    {
        public void Configure(EntityTypeBuilder<Morador> builder)
        {
            builder.HasKey(p => p.MoradorId);

            builder.HasIndex(p => p.CPF)
                .IsUnique();

            builder.Property(p => p.Nome)
                .HasColumnType("Varchar(100)")
                .IsRequired();

            builder.Property(p => p.CPF)
                .HasColumnType("Varchar(11)")
                .IsRequired();

            builder.Property(p => p.DataNascimento)
                .HasColumnType("Date");

            builder.Property(p => p.Email)
                .HasColumnType("Varchar(50)");

            builder.Property(p => p.Telefone)
                .HasColumnType("Varchar(20)");

            builder.HasOne<Apartamento>()
                .WithMany()
                .HasForeignKey(p => p.ApartamentoId);
        }
    }
}

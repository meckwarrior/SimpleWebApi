using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PorterWebApi.Domain.Entities;
using PorterWebApi.Infra.Data.EntityConfig;
using System;
using System.IO;
using System.Linq;

namespace PorterWebApi.Infra.Data.Context
{
    public class PorterContext : DbContext
    {
        public PorterContext()
            : base() { }

        public DbSet<Condominio> Condominios { get; set; }
        public DbSet<Bloco> Blocos { get; set; }
        public DbSet<Apartamento> Apartamentos { get; set; }
        public DbSet<Morador> Moradores { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new CondominioConfiguration().Configure(modelBuilder.Entity<Condominio>());
            new BlocoConfiguration().Configure(modelBuilder.Entity<Bloco>());
            new ApartamentoConfiguration().Configure(modelBuilder.Entity<Apartamento>());
            new MoradorConfiguration().Configure(modelBuilder.Entity<Morador>());

            //base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionService.connectionString);
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;

                if (entry.State == EntityState.Modified)
                    entry.Property("DataCadastro").IsModified = false;
            }

            try
            {
                return base.SaveChanges();
            }
            catch (Exception e)
            {
                if ((bool)e.InnerException?.Message?.Contains("duplicate key"))
                    throw new Exception("ERRO: Cadastro Duplicado!");
                else
                    throw;
            }
        }
    }
}

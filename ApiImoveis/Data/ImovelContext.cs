using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ApiImoveis.Models;

#nullable disable

namespace ApiImoveis.Data
{
    public partial class ImovelContext : DbContext
    {

        public ImovelContext(DbContextOptions<ImovelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Imoveltb> Imoveltbs { get; set; }
        public virtual DbSet<Locacao> Locacaos { get; set; }
        public virtual DbSet<Proprietario> Proprietarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("name=ImovelDB", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.30-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.Cpf)
                    .HasName("PRIMARY");

                entity.ToTable("cliente");

                entity.HasIndex(e => e.Cpf, "idCliente_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Cpf)
                    .ValueGeneratedNever()
                    .HasColumnName("CPF");

                entity.Property(e => e.Email).HasMaxLength(45);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.Telefone).HasMaxLength(45);
            });

            modelBuilder.Entity<Imoveltb>(entity =>
            {
                entity.HasKey(e => e.IdImovel)
                    .HasName("PRIMARY");

                entity.ToTable("imoveltb");

                entity.HasIndex(e => e.IdImovel, "idImovel_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdImovel)
                    .ValueGeneratedNever()
                    .HasColumnName("idImovel");

                entity.Property(e => e.Bairro)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Cep).HasColumnName("CEP");

                entity.Property(e => e.Cidade)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Complemento)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Logradouro)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Numero)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Locacao>(entity =>
            {
                entity.HasKey(e => e.IdLocacao)
                    .HasName("PRIMARY");

                entity.ToTable("locacao");

                entity.HasIndex(e => e.IdLocacao, "idLocacao_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdLocacao)
                    .ValueGeneratedNever()
                    .HasColumnName("idLocacao");

                entity.Property(e => e.Cpflocatario).HasColumnName("CPFLocatario");
            });

            modelBuilder.Entity<Proprietario>(entity =>
            {
                entity.HasKey(e => e.IdProprietario)
                    .HasName("PRIMARY");

                entity.ToTable("proprietario");

                entity.HasIndex(e => e.IdProprietario, "CPF_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdProprietario)
                    .ValueGeneratedNever()
                    .HasColumnName("idProprietario");

                entity.Property(e => e.Cpf).HasColumnName("CPF");

                entity.Property(e => e.IdImovel).HasColumnName("idImovel");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

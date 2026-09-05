using ClinicaASPNet.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicaASPNet.Data
{
    public class ClinicaDbContext : DbContext
    {
        public ClinicaDbContext(DbContextOptions<ClinicaDbContext> options) : base(options)
        {

        }
      
        

        public DbSet<Paciente> Pacientes => Set<Paciente>();
        public DbSet<Profissional> Profissionais => Set<Profissional>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Profissional>(
                entity =>
                {
                    entity.ToTable("Profissionais");
                    entity.HasKey(p => p.Id);
                    entity.Property(p => p.Nome)
                    .HasMaxLength(100)
                    .HasColumnType("varchar(100)");
                    entity.Property(p => p.CPF)
                    .HasColumnType("varchar(11)");

                    entity.HasIndex(p => p.CPF)
                    .IsUnique();
                }
                );
            modelBuilder.Entity<Paciente>(
                entity =>
                {
                    entity.ToTable("Pacientes");
                    entity.HasKey(p => p.Id);
                    entity.Property(p => p.Nome)
                    .HasMaxLength(100)
                    .IsRequired();
                    entity.Property(p => p.Cpf)
                    .HasColumnType("varchar(100)")
                    .IsRequired();
                    entity.HasIndex(p => p.Cpf)
                    .IsUnique();
                    entity.Property(p => p.Telefone)
                     .HasMaxLength(100)
                      .IsRequired();
                    entity.Property(p => p.DataNascimento)
                    .HasColumnType("date");
                    entity.Property(p => p.CriadoEm)
                    .HasColumnType("datetime2");
                    entity.Property(p => p.AtualizadoEm)
                   .HasColumnType("datetime2");

                }


                );

        }
    }
}

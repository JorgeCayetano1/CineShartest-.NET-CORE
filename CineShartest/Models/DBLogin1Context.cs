using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CineShartest.Models
{
    public partial class DBLogin1Context : DbContext
    {
        public DBLogin1Context()
        {
        }

        public DBLogin1Context(DbContextOptions<DBLogin1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Usuario> UsuariosDbSet { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Data Source=LAPTOP-RGEESPUT;Initial Catalog=DBLogin1;User ID=sa;Password=123456;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.CodSu)
                    .HasName("PK__Usuario__0A1BAD23375F6218");

                entity.ToTable("Usuario");

                entity.Property(e => e.CodSu).HasColumnName("COD_SU");

                entity.Property(e => e.SuEmail)
                    .HasMaxLength(120)
                    .IsUnicode(false)
                    .HasColumnName("SU_EMAIL");

                entity.Property(e => e.SuEst)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("SU_EST");

                entity.Property(e => e.SuNick)
                    .HasMaxLength(120)
                    .IsUnicode(false)
                    .HasColumnName("SU_NICK");

                entity.Property(e => e.SuPass)
                    .HasMaxLength(120)
                    .IsUnicode(false)
                    .HasColumnName("SU_PASS");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

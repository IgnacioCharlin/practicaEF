using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ClasificadorAnimales.Data.EF
{
    public partial class _20221CPracticaEFContext : DbContext
    {
        private _20221CPracticaEFContext contexto;

        public _20221CPracticaEFContext()
        {
        }

        public _20221CPracticaEFContext(DbContextOptions<_20221CPracticaEFContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Animal> Animals { get; set; }
        public virtual DbSet<TipoAnimal> TipoAnimals { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=NBAR14521\\SQLEXPRESS;Database=2022-1C-Practica-EF;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Animal>(entity =>
            {
                entity.HasKey(e => e.IdAnimal);

                entity.ToTable("Animal");

                entity.Property(e => e.NombreEspecie)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.IdTipoAnimalNavigation)
                    .WithMany(p => p.Animals)
                    .HasForeignKey(d => d.IdTipoAnimal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Animal_TipoAnimal");
            });

            modelBuilder.Entity<TipoAnimal>(entity =>
            {
                entity.HasKey(e => e.IdTipoAnimal);

                entity.ToTable("TipoAnimal");

                entity.Property(e => e.IdTipoAnimal).ValueGeneratedNever();

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

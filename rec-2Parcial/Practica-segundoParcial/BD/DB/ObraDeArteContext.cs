using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BD.DB
{
    public partial class ObraDeArteContext : DbContext
    {
        public ObraDeArteContext()
        {
        }

        public ObraDeArteContext(DbContextOptions<ObraDeArteContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ObraDeArte> ObraDeArtes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=NBAR14521\\SQLEXPRESS;Database=ObraDeArte;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<ObraDeArte>(entity =>
            {
                entity.ToTable("ObraDeArte");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("nombre");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

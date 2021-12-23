using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Petalos.Models
{
    public partial class floresContext : DbContext
    {
        public floresContext()
        {
        }

        public floresContext(DbContextOptions<floresContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Datosflores> Datosflores { get; set; }
        public virtual DbSet<Imagenesflores> Imagenesflores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Datosflores>(entity =>
            {
                entity.HasKey(e => e.Idflor);

                entity.ToTable("datosflores");

                entity.Property(e => e.Idflor).HasColumnName("idflor");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("descripcion")
                    .HasColumnType("text");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Nombrecientifico)
                    .IsRequired()
                    .HasColumnName("nombrecientifico")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Nombrecomun)
                    .IsRequired()
                    .HasColumnName("nombrecomun")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.Origen)
                    .IsRequired()
                    .HasColumnName("origen")
                    .HasColumnType("varchar(300)");
            });

            modelBuilder.Entity<Imagenesflores>(entity =>
            {
                entity.HasKey(e => e.Idimagen);

                entity.ToTable("imagenesflores");

                entity.HasIndex(e => e.Idflor)
                    .HasName("FK_imagenesflores_1");

                entity.Property(e => e.Idimagen).HasColumnName("idimagen");

                entity.Property(e => e.Idflor).HasColumnName("idflor");

                entity.Property(e => e.Nombreimagen)
                    .IsRequired()
                    .HasColumnName("nombreimagen")
                    .HasColumnType("varchar(100)");

                entity.HasOne(d => d.IdflorNavigation)
                    .WithMany(p => p.Imagenesflores)
                    .HasForeignKey(d => d.Idflor)
                    .HasConstraintName("FK_imagenesflores_1");
            });
        }
    }
}

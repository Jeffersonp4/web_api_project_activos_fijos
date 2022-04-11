using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace web_api_project_activos_fijos.Entities
{
    public partial class n5xki0m8szpeqpytContext : IdentityDbContext
    {
        public n5xki0m8szpeqpytContext()
        {
        }

        public n5xki0m8szpeqpytContext(DbContextOptions<n5xki0m8szpeqpytContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ActivoFijo> ActivoFijos { get; set; } = null!;
        public virtual DbSet<Empleado> Empleados { get; set; } = null!;
        public virtual DbSet<TipoActivo> TipoActivos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<ActivoFijo>(entity =>
            {
                entity.ToTable("activo_fijo");

                entity.UseCollation("utf8mb4_general_ci");

                entity.HasIndex(e => e.CodigoTipoActivo, "FK_Activo_ActivoFijos");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AreaUsuaria)
                    .HasMaxLength(255)
                    .HasColumnName("Area_usuaria");

                entity.Property(e => e.CodigoTipoActivo).HasColumnName("Codigo_tipoActivo");

                entity.Property(e => e.CostoAdquisicion).HasColumnName("Costo_adquisicion");

                entity.Property(e => e.DescripcionActivo)
                    .HasMaxLength(255)
                    .HasColumnName("Descripcion_activo");

                entity.Property(e => e.FechaAdquisicion)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_adquisicion");

                entity.Property(e => e.ModeloEquipo)
                    .HasMaxLength(255)
                    .HasColumnName("modelo_equipo");

                entity.Property(e => e.NumRegistro).HasColumnName("Num_registro");

                entity.Property(e => e.ValorNeto)
                    .HasPrecision(10)
                    .HasColumnName("Valor_neto");

                entity.HasOne(d => d.CodigoTipoActivoNavigation)
                    .WithMany(p => p.ActivoFijos)
                    .HasPrincipalKey(p => p.Codigo)
                    .HasForeignKey(d => d.CodigoTipoActivo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Activo_ActivoFijos");
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.ToTable("empleado");

                entity.UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(255)
                    .HasColumnName("apellido");

                entity.Property(e => e.Cedula)
                    .HasMaxLength(255)
                    .HasColumnName("cedula");

                entity.Property(e => e.Celular)
                    .HasMaxLength(255)
                    .HasColumnName("celular");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(255)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<TipoActivo>(entity =>
            {
                entity.ToTable("tipo_activos");

                entity.UseCollation("utf8mb4_general_ci");

                entity.HasIndex(e => e.Codigo, "llave_unica")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Codigo).HasColumnName("codigo");

                entity.Property(e => e.NumeroActivofijo)
                    .HasMaxLength(255)
                    .HasColumnName("numero_activofijo");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

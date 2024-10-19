using System;
using System.Collections.Generic;
using CRUD_COLEGIO_APP_0609.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_COLEGIO_APP_0609.Context;

public partial class ColegioPgContext : DbContext
{
    public ColegioPgContext()
    {
    }

    public ColegioPgContext(DbContextOptions<ColegioPgContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Alumno> Alumnos { get; set; }

    public virtual DbSet<Curso> Cursos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Alumno>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Alumnos__3214EC07233B8558");

            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IdCursos).HasColumnName("Id_cursos");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdCursosNavigation).WithMany(p => p.Alumnos)
                .HasForeignKey(d => d.IdCursos)
                .HasConstraintName("FK__Alumnos__Id_curs__398D8EEE");
        });

        modelBuilder.Entity<Curso>(entity =>
        {
            entity.HasKey(e => e.IdCursos).HasName("PK__Cursos__F802724671A45914");

            entity.Property(e => e.IdCursos).HasColumnName("Id_cursos");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

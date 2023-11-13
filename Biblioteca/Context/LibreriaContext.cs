using System;
using System.Collections.Generic;
using Biblioteca.Models;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Context;

public partial class LibreriaContext : DbContext
{
    public LibreriaContext()
    {
    }

    public LibreriaContext(DbContextOptions<LibreriaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Autor> Autors { get; set; }

    public virtual DbSet<Libro> Libros { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-U0CTJAL\\SQLEXPRESS;Database=libreria;Trust Server Certificate=true;User Id=sa;Password=12345;MultipleActiveResultSets=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Autor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Autor__3213E83FB52D90A0");

            entity.ToTable("Autor");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Libro>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Libro__3213E83F45298560");

            entity.ToTable("Libro");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.AuthorId).HasColumnName("author_id");
            entity.Property(e => e.Chapters).HasColumnName("chapters");
            entity.Property(e => e.Pages).HasColumnName("pages");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("title");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

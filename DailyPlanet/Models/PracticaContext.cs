using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DailyPlanet.Models;

public partial class PracticaContext : DbContext
{
    public PracticaContext()
    {
    }

    public PracticaContext(DbContextOptions<PracticaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<News> News { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-4B07KGD;Database=practica;INTEGRATED SECURITY= true;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<News>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__news__3213E83F8FA52039");

            entity.ToTable("news");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Body)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("body");
            entity.Property(e => e.Datetime)
                .HasColumnType("datetime")
                .HasColumnName("datetime");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("title");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Email).HasName("PK__users__AB6E61654FCB769A");

            entity.ToTable("users");

            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.AccountId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("accountId");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("password");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

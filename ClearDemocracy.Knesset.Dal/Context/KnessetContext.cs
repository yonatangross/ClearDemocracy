using System;
using System.Collections.Generic;
using ClearDemocracy.Knesset.Dal.Models;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace ClearDemocracy.Knesset.Dal.Context;

public partial class KnessetContext : DbContext
{
    public KnessetContext()
    {
    }

    public KnessetContext(DbContextOptions<KnessetContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Faction> Factions { get; set; }

    public virtual DbSet<Models.Knesset> Knessets { get; set; }

    public virtual DbSet<Mk> Mks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;database=Politics;user=root;password=yonatan1234", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.37-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Faction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("factions");

            entity.HasIndex(e => e.KnessetId, "KnessetID");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.KnessetId).HasColumnName("KnessetID");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255);

            entity.HasOne(d => d.Knesset).WithMany(p => p.Factions)
                .HasForeignKey(d => d.KnessetId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("factions_ibfk_1");
        });

        modelBuilder.Entity<Models.Knesset>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("knessets");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.FromDate).HasColumnType("datetime");
            entity.Property(e => e.FromDateHeb)
                .IsRequired()
                .HasMaxLength(255);
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255);
            entity.Property(e => e.ToDate).HasColumnType("datetime");
            entity.Property(e => e.ToDateHeb).HasMaxLength(255);
        });

        modelBuilder.Entity<Mk>(entity =>
        {
            entity.HasKey(e => e.MkId).HasName("PRIMARY");

            entity.ToTable("mks");

            entity.Property(e => e.MkId).ValueGeneratedNever();
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.Facebook).HasMaxLength(255);
            entity.Property(e => e.FactionName).HasMaxLength(255);
            entity.Property(e => e.Fax).HasMaxLength(255);
            entity.Property(e => e.FirstLetter)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.Firstname).HasMaxLength(100);
            entity.Property(e => e.ImagePath).HasMaxLength(255);
            entity.Property(e => e.Instagram).HasMaxLength(255);
            entity.Property(e => e.Lastname).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(100);
            entity.Property(e => e.Twitter).HasMaxLength(255);
            entity.Property(e => e.WebsiteUrl).HasMaxLength(255);
            entity.Property(e => e.Youtube).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

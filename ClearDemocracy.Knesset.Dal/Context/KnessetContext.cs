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

    public virtual DbSet<faction> Factions { get; set; }

    public virtual DbSet<government> Governments { get; set; }

    public virtual DbSet<Knesset> Knessets { get; set; }

    public virtual DbSet<minister> Ministers { get; set; }

    public virtual DbSet<mk> Mks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;database=Politics;user=root;password=yonatan1234", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.37-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<faction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("faction");

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
                .HasConstraintName("faction_ibfk_1");
        });

        modelBuilder.Entity<government>(entity =>
        {
            entity.HasKey(e => e.GovId).HasName("PRIMARY");

            entity.ToTable("government");

            entity.Property(e => e.GovId).ValueGeneratedNever();
            entity.Property(e => e.GovBannerImage).HasMaxLength(255);
            entity.Property(e => e.GovCurrent).HasColumnType("bit(1)");
            entity.Property(e => e.GovFinishDate).HasColumnType("datetime");
            entity.Property(e => e.GovFinishDateStr).HasMaxLength(255);
            entity.Property(e => e.GovName)
                .IsRequired()
                .HasMaxLength(255);
            entity.Property(e => e.GovNamedFinishDateStr).HasMaxLength(255);
            entity.Property(e => e.GovNamedStartDateStr).HasMaxLength(255);
            entity.Property(e => e.GovNotes).HasColumnType("text");
            entity.Property(e => e.GovPmimage)
                .HasMaxLength(255)
                .HasColumnName("GovPMImage");
            entity.Property(e => e.GovStartDate).HasColumnType("datetime");
            entity.Property(e => e.GovStartDateStr).HasMaxLength(255);
            entity.Property(e => e.KnessetNames).HasMaxLength(255);
            entity.Property(e => e.SearchedGov).HasColumnType("bit(1)");
        });

        modelBuilder.Entity<Knesset>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("knesset");

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

        modelBuilder.Entity<minister>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("minister");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.FactionId).HasColumnName("faction_id");
            entity.Property(e => e.FactionName).HasMaxLength(255);
            entity.Property(e => e.FinishDateStr).HasMaxLength(255);
            entity.Property(e => e.FkSanId).HasColumnName("FK_SanID");
            entity.Property(e => e.GoPositionId).HasColumnName("GO_PositionID");
            entity.Property(e => e.GovFinishDate).HasColumnType("datetime");
            entity.Property(e => e.GovFinishDateStr).HasMaxLength(255);
            entity.Property(e => e.GovFinishDateStr2).HasMaxLength(255);
            entity.Property(e => e.GovGroups).HasMaxLength(255);
            entity.Property(e => e.GovStartDate).HasColumnType("datetime");
            entity.Property(e => e.GovStartDateStr).HasMaxLength(255);
            entity.Property(e => e.GovStartDateStr2).HasMaxLength(255);
            entity.Property(e => e.GovermentName)
                .IsRequired()
                .HasMaxLength(255);
            entity.Property(e => e.IsMk)
                .HasColumnType("bit(1)")
                .HasColumnName("IsMK");
            entity.Property(e => e.Knesset).HasColumnName("knesset");
            entity.Property(e => e.KnessetName)
                .IsRequired()
                .HasMaxLength(255);
            entity.Property(e => e.LuGender).HasColumnName("LU_Gender");
            entity.Property(e => e.MinistryName)
                .IsRequired()
                .HasMaxLength(255);
            entity.Property(e => e.MkName)
                .IsRequired()
                .HasMaxLength(255);
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255);
            entity.Property(e => e.Notes).HasColumnType("text");
            entity.Property(e => e.PositionFinishedDate).HasColumnType("datetime");
            entity.Property(e => e.PositionName)
                .IsRequired()
                .HasMaxLength(255);
            entity.Property(e => e.PositionStratDate).HasColumnType("datetime");
            entity.Property(e => e.Rnk).HasColumnName("RNK");
            entity.Property(e => e.SanPositionId).HasColumnName("SAN_PositionId");
            entity.Property(e => e.StartDateStr).HasMaxLength(255);
            entity.Property(e => e.TypeId).HasColumnName("TypeID");
        });

        modelBuilder.Entity<mk>(entity =>
        {
            entity.HasKey(e => e.MkId).HasName("PRIMARY");

            entity.ToTable("mk");

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

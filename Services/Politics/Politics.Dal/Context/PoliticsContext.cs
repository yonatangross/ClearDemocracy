using Microsoft.EntityFrameworkCore;
using Politics.Dal.Models;

namespace Politics.Dal.Context;

public partial class PoliticsContext : DbContext
{
    public PoliticsContext()
    {
    }

    public PoliticsContext(DbContextOptions<PoliticsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Faction> Factions { get; set; }

    public virtual DbSet<Government> Governments { get; set; }

    public virtual DbSet<Knesset> Knessets { get; set; }

    public virtual DbSet<Minister> Ministers { get; set; }

    public virtual DbSet<Mk> Mks { get; set; }

    public virtual DbSet<Sanction> Sanctions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;port=3307;database=politics;user=root;password=yonatan1234", ServerVersion.Parse("8.0.37-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Faction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasOne(d => d.Knesset).WithMany(p => p.Factions).HasConstraintName("faction_ibfk_1");
        });

        modelBuilder.Entity<Government>(entity =>
        {
            entity.HasKey(e => e.GovId).HasName("PRIMARY");
        });

        modelBuilder.Entity<Knesset>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
        });

        modelBuilder.Entity<Minister>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasOne(d => d.Faction).WithMany(p => p.Ministers)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("minister_ibfk_1");

            entity.HasOne(d => d.FkSan).WithMany(p => p.Ministers).HasConstraintName("minister_ibfk_4");

            entity.HasOne(d => d.Government).WithMany(p => p.Ministers).HasConstraintName("minister_ibfk_3");

            entity.HasOne(d => d.Knesset).WithMany(p => p.Ministers).HasConstraintName("minister_ibfk_2");
        });

        modelBuilder.Entity<Mk>(entity =>
        {
            entity.HasKey(e => e.MkId).HasName("PRIMARY");

            entity.Property(e => e.FirstLetter).IsFixedLength();

            entity.HasOne(d => d.Faction).WithMany(p => p.Mks)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("mk_ibfk_1");
        });

        modelBuilder.Entity<Sanction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

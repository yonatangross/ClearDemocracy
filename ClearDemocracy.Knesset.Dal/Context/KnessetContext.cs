using ClearDemocracy.Knesset.Dal.Models;
using Microsoft.EntityFrameworkCore;

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

    public virtual DbSet<Mk> Mks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;database=Politics;user=root;password=yonatan1234", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.37-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

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

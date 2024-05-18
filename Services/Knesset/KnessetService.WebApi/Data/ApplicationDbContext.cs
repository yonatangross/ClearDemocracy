using KnessetService.BL.Models;
using Microsoft.EntityFrameworkCore;

namespace KnessetService.WebApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Mk> Mks { get; set; }
        public DbSet<Faction> Factions { get; set; }
        public DbSet<Knesset> Knessets { get; set; }
        public DbSet<Government> Governments { get; set; }
        public DbSet<Minister> Ministers { get; set; }
    }
}

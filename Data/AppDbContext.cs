using GSDrones.Models;
using Microsoft.EntityFrameworkCore;

namespace GSDrones.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Drone> Drones { get; set; }
        public DbSet<Missao> Missoes { get; set; }
        public DbSet<Suprimento> Suprimentos { get; set; }
        public DbSet<SuprimentoMissao> SuprimentosMissoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}

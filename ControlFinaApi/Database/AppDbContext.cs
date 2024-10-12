using ControlFinaApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace ControlFinaApi.Database
{
    public class AppDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<History> Histories { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}

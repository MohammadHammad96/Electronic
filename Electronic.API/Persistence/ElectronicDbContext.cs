using Electronic.API.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Electronic.API.Persistence
{
    public class ElectronicDbContext : DbContext
    {
        public ElectronicDbContext(DbContextOptions<ElectronicDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>()
                .HasIndex(c => c.Name)
                .IsUnique();
        }
    }
}

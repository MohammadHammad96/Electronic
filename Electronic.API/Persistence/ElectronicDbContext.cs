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
        public DbSet<SubCategory> SubCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>()
                .HasIndex(c => c.Name)
                .IsUnique();

            modelBuilder.Entity<SubCategory>()
                .HasIndex(s => new
                {
                    s.Name,
                    s.CategoryId
                })
                .IsUnique();
        }
    }
}

using BulkyWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "ACTION", DisplayOrder = 21 },
                new Category { Id = 2, Name = "SEED", DisplayOrder = 5 },
                new Category { Id = 3, Name = "TABLE", DisplayOrder = 11 }
            );
        }
    }
}

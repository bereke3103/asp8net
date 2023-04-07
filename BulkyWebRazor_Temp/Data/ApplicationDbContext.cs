using BulkyWebRazor_Temp.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyWebRazor_Temp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id=1, Name="Action", DisplayOrder=21 },
                new Category { Id=2, Name="Non Action", DisplayOrder=33 },
                new Category { Id=3, Name="Me", DisplayOrder=79 }
                );
        }
  
    }
}

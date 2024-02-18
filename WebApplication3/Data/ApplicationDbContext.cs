using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;
using Type = WebApplication3.Models.Type;

namespace WebApplication3.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        { 

        }
        public DbSet<Company> companies { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Type> types { get; set; }
        public DbSet<Blog> blogs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>().HasData(new Company {Id=1 , Name="Nike" },
                new Company { Id=2 , Name="Adidas"});
            modelBuilder.Entity<Type>().HasData(new Type { Id = 1, Name = "Drama" },
              new Type { Id = 2, Name = "Comedy" });

        }
    }
}

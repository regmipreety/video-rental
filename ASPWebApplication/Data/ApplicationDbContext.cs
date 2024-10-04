using ASPWebApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPWebApplication.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
                
        }

        public DbSet<Category> Categories{ get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id= 1, Name = "Action", DisplayOrder = 1},
                new Category { Id = 2, Name = "Comedy", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Drama", DisplayOrder = 3 }

                );

            modelBuilder.Entity<Product>().HasData(
                new Product {
                    Id = 1, 
                    Title = "Rock in the Ocean", 
                    Director = "Ron Parker", 
                    Description = " This is based on true event. ", 
                    ListPrice= 30,
                    Price= 27,
                    Price50=25
                   },
                new Product
                {
                    Id = 2,
                    Title = "Harry Porter",
                    Director = "JK Rowling",
                    Description = " Harry Porter and his friends go on an adventure. ",
                    ListPrice = 300,
                    Price = 270,
                    Price50 = 250
                },
                new Product
                {
                    Id = 3,
                    Title = "Pretty Little Liars",
                    Director = "Rina Ghosling",
                    Description = " It is a murder mystery. ",
                    ListPrice = 300,
                    Price = 270,
                    Price50 = 250
                }


                );
        }
    }
}

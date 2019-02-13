using Microsoft.EntityFrameworkCore;
using Recipes.Domain.Entities;
using System;

namespace Recipes.Data
{
    public class RecipesContext : DbContext
    {
        public RecipesContext(DbContextOptions<RecipesContext> options) : base(options) { }

        public DbSet<Recipe> Recipes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Recipe>().HasData(
                new Recipe { Id = 1, Created = DateTime.Now, Modified = DateTime.Now, Name = "Chilli Con Carne", Rating = 3 },
                new Recipe { Id = 2, Created = DateTime.Now, Modified = DateTime.Now, Name = "Spagetti Bolognese", Rating = 5 },
                new Recipe { Id = 3, Created = DateTime.Now, Modified = DateTime.Now, Name = "Chicken Tikka Masala", Rating = 4.5 },
                new Recipe { Id = 4, Created = DateTime.Now, Modified = DateTime.Now, Name = "Sausage Casserole", Rating = 4.2 }
            );
        }
    }
}

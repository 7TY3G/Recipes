using Microsoft.EntityFrameworkCore;
using Recipes.Data.Seeding;
using Recipes.Domain.Entities;

namespace Recipes.Data
{
    public class RecipesContext : DbContext
    {
        public RecipesContext(DbContextOptions<RecipesContext> options) : base(options) { }

        public DbSet<Recipe> Recipe { get; set; }
        public DbSet<Ingredient> Ingredient { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<RecipeIngredient>(e => {
                e.HasKey(x => x.Id);
                e.Property(x => x.IngredientId).IsRequired();
                e.HasOne<Ingredient>()
                    .WithMany()
                    .HasForeignKey(x => x.IngredientId);
                e.ToTable("RecipeIngredient");
            });
        }
    }
}

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Recipes.Data.DataModels;
using Recipes.Data.DataModels.Security;

namespace Recipes.Data
{
    public class RecipesContext : IdentityDbContext<User, Role, string>
    {
        public RecipesContext(DbContextOptions<RecipesContext> options) : base(options) { }

        public DbSet<RecipeEntity> Recipe { get; set; }

        public DbSet<IngredientEntity> Ingredient { get; set; }

        public DbSet<RecipeIngredientEntity> RecipeIngredients { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<RecipeIngredientEntity>()
                .HasKey(ri => new { ri.RecipeId, ri.IngredientId });

            builder.Entity<FavouriteRecipes>()
                .HasKey(fr => new { fr.UserId, fr.RecipeId });

            builder.Entity<FavouriteRecipes>()
                .HasOne(fr => fr.User)
                .WithMany(u => u.FavouriteRecipes);
        }
    }
}

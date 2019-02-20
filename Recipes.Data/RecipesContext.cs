using Microsoft.EntityFrameworkCore;
using Recipes.Data.DataModels;

namespace Recipes.Data
{
    public class RecipesContext : DbContext
    {
        public RecipesContext(DbContextOptions<RecipesContext> options) : base(options) { }

        public DbSet<Recipe> Recipe { get; set; }
        public DbSet<Ingredient> Ingredient { get; set; }
    }
}

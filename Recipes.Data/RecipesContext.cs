using Microsoft.EntityFrameworkCore;
using Recipes.Domain.Entities;

namespace Recipes.Data
{
    public class RecipesContext : DbContext
    {
        public RecipesContext(DbContextOptions<RecipesContext> options) : base(options) { }

        public DbSet<Recipe> Recipes { get; set; }
    }
}

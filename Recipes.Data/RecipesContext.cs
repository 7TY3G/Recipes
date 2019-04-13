using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Recipes.Data.DataModels;
using Recipes.Data.DataModels.Security;

namespace Recipes.Data
{
    public class RecipesContext : IdentityDbContext<User, Role, string>
    {
        public RecipesContext(DbContextOptions<RecipesContext> options) : base(options) { }

        public DbSet<Recipe> Recipe { get; set; }

        public DbSet<Ingredient> Ingredient { get; set; }
    }
}

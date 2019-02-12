using Recipes.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Recipes.Data.Repos
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly RecipesContext context;
        private const int favouritesCount = 3;

        public RecipeRepository(RecipesContext context)
        {
            this.context = context;
        }

        public IEnumerable<Recipe> GetAllRecipes()
        {
            return this.context.Recipes.AsEnumerable();
        }

        public IEnumerable<Recipe> GetFavouriteRecipes()
        {
            return this.context.Recipes.Take(favouritesCount).AsEnumerable();
        }

        public void AddRecipe(Recipe recipe)
        {
            this.context.Recipes.Add(recipe);
            this.context.SaveChanges();
        }
    }
}

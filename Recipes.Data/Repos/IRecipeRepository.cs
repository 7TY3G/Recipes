using Recipes.Domain.Entities;
using System.Collections.Generic;

namespace Recipes.Data.Repos
{
    public interface IRecipeRepository
    {
        IEnumerable<Recipe> GetAllRecipes();
        IEnumerable<Recipe> GetFavouriteRecipes();
        void AddRecipe(Recipe recipe);
    }
}

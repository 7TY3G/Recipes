using Recipes.Domain.Entities;
using System.Collections.Generic;

namespace Recipes.Data.Repos
{
    public interface IRecipeRepository
    {
        IEnumerable<Recipe> GetAllRecipes();
        IEnumerable<Recipe> GetFavouriteRecipes();
        Recipe GetById(int id);
        void AddRecipe(Recipe recipe);
        void UpdateRecipe(Recipe recipe);
    }
}

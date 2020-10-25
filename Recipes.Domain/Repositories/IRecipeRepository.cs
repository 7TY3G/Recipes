using System.Collections.Generic;
using Recipes.Domain.Entities;

namespace Recipes.Domain.Repositories
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

using System.Collections.Generic;
using Recipes.Domain.Entities;

namespace Recipes.Domain.Repositories
{
    public interface IRecipeRepository
    {
        IEnumerable<RecipeModel> GetAllRecipes();
        IEnumerable<RecipeModel> GetFavouriteRecipes();
        RecipeModel GetById(int id);
        void AddRecipe(RecipeModel recipe);
        void UpdateRecipe(RecipeModel recipe);
    }
}

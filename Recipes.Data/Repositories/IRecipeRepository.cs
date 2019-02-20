using Recipes.Data.DataModels;
using Recipes.Domain.Entities;
using System.Collections.Generic;

namespace Recipes.Data.Repos
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

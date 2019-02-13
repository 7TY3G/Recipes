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
            return this.context.Recipes.OrderByDescending(x => x.Rating).Take(favouritesCount).AsEnumerable();
        }

        public Recipe GetById(int id)
        {
            var recipe = this.context.Recipes.FirstOrDefault(x => x.Id == id);

            if (recipe != null)
            {
                return recipe;
            }

            return null;
        }

        public void AddRecipe(Recipe recipe)
        {
            this.context.Recipes.Add(recipe);
            this.context.SaveChanges();
        }

        public void UpdateRecipe(Recipe recipe)
        {
            var oldRecipe = this.context.Recipes.FirstOrDefault(x => x.Id == recipe.Id);

            if (oldRecipe != null)
            {
                oldRecipe.Name = recipe.Name;
                oldRecipe.Rating = recipe.Rating;
                this.context.SaveChanges();
                return;
            }
             // TODO: Should throw exception
            return;
        }
    }
}

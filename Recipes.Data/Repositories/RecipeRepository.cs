using Microsoft.EntityFrameworkCore;
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
            return this.context.Recipe.AsEnumerable();
        }

        public IEnumerable<Recipe> GetFavouriteRecipes()
        {
            return this.context.Recipe.OrderByDescending(x => x.Rating).Take(favouritesCount).AsEnumerable();
        }

        public Recipe GetById(int id)
        {
            var recipe = this.context.Recipe
                .Include(x => x.Ingredients)
                .FirstOrDefault(x => x.Id == id);

            if (recipe != null)
            {
                return recipe;
            }

            return null;
        }

        public void AddRecipe(Recipe recipe)
        {
            this.context.Recipe.Add(recipe);
            this.context.SaveChanges();
        }

        public void UpdateRecipe(Recipe recipe)
        {
            var oldRecipe = this.context.Recipe
                .Include(x => x.Ingredients)
                .FirstOrDefault(x => x.Id == recipe.Id);

            if (oldRecipe != null)
            {
                oldRecipe.Name = recipe.Name;
                oldRecipe.Rating = recipe.Rating;
                oldRecipe.Ingredients = recipe.Ingredients;
                this.context.SaveChanges();
                return;
            }
             // TODO: Should throw exception
            return;
        }
    }
}

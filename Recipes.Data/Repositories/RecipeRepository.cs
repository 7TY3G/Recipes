using Microsoft.EntityFrameworkCore;
using Recipes.Domain.Entities;
using System;
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
                .SingleOrDefault(x => x.Id == id);

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
            var currentRecipe = this.context.Recipe
                .Include(x => x.Ingredients)
                .FirstOrDefault(x => x.Id == recipe.Id);

            if (currentRecipe != null)
            {
                currentRecipe.Name = recipe.Name;
                currentRecipe.Rating = recipe.Rating;

                UpdateExistingRecipeIngredients(currentRecipe.Ingredients, recipe.Ingredients.Where(x => x.Id != 0).ToList());
                AddNewIngredientsToRecipe(recipe.Ingredients.Where(x => x.Id == 0), currentRecipe);

                this.context.Recipe.Update(currentRecipe);
                this.context.SaveChanges();

                return;
            }

            // TODO: Should throw exception
            return;
        }

        private void UpdateExistingRecipeIngredients(ICollection<RecipeIngredient> existingIngredients, ICollection<RecipeIngredient> updatedIngredients)
        {
            var itemsToRemove = new List<RecipeIngredient>();

            foreach (var existingIngredient in existingIngredients)
            {
                var updatedIngredient = updatedIngredients.Where(x => x.Id == existingIngredient.Id).SingleOrDefault();

                if (updatedIngredient != null && (existingIngredient.Measurement != updatedIngredient.Measurement
                    || existingIngredient.Amount != updatedIngredient.Amount))
                {
                    existingIngredients.First(x => x.Id == existingIngredient.Id).Amount = updatedIngredient.Amount;
                    existingIngredients.First(x => x.Id == existingIngredient.Id).Measurement = updatedIngredient.Measurement;
                }
                else if (updatedIngredient == null)
                {
                    itemsToRemove.Add(existingIngredient);
                }
            }

            foreach (var item in itemsToRemove)
            {
                existingIngredients.Remove(item);
            }
        }

        private void AddNewIngredientsToRecipe(IEnumerable<RecipeIngredient> ingredients, Recipe currentRecipe)
        {
            foreach (var ingredient in ingredients)
            {
                var newRecipeIngredient = new RecipeIngredient()
                {
                    RecipeId = currentRecipe.Id,
                    Amount = ingredient.Amount,
                    Measurement = ingredient.Measurement,
                    IngredientId = ingredient.IngredientId
                };

                currentRecipe.Ingredients.Add(newRecipeIngredient);
            }
        }
    }
}

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Recipes.Data.DataModels;
using Recipes.Domain.Entities;
using Recipes.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Recipes.Data.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly RecipesContext context;
        private readonly ILogger logger;
        private readonly IMapper mapper;
        private const int favouritesCount = 3;

        public RecipeRepository(RecipesContext context, ILogger<RecipeRepository> logger, IMapper mapper)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public IEnumerable<Recipe> GetAllRecipes()
        {
            this.logger.LogInformation("RecipeRepo: Get All Recipes");
            var recipes = this.context.Recipe.AsEnumerable();
            return mapper.Map<List<Recipe>>(recipes.ToList());
        }

        public IEnumerable<Recipe> GetFavouriteRecipes()
        {
            var recipes = this.context.Recipe.OrderByDescending(x => x.Rating).Take(favouritesCount).AsEnumerable();
            return mapper.Map<List<Recipe>>(recipes.ToList());
        }

        public Recipe GetById(int id)
        {
            var recipe = this.context.Recipe
                .Include(x => x.Ingredients)
                .ThenInclude(i => i.Ingredient)
                .SingleOrDefault(x => x.Id == id);

            if (recipe != null)
            {
                return mapper.Map<Recipe>(recipe);
            }

            return null;
        }

        public void AddRecipe(Recipe recipe)
        {
            var mappedRecipe = mapper.Map<RecipeEntity>(recipe);

            this.context.Recipe.Add(mappedRecipe);
            this.context.SaveChanges();
        }

        public void UpdateRecipe(Recipe recipe)
        {
            var mappedRecipe = mapper.Map<RecipeEntity>(recipe);

            var currentRecipe = this.context.Recipe
                .Include(x => x.Ingredients)
                .FirstOrDefault(x => x.Id == recipe.Id);

            if (currentRecipe is null)
            {
                // TODO: Should throw exception?
            }

            currentRecipe.Name = mappedRecipe.Name;
            currentRecipe.Rating = mappedRecipe.Rating;

            UpdateExistingIngredients(currentRecipe.Ingredients, mappedRecipe.Ingredients);
            AddNewIngredients(currentRecipe, mappedRecipe.Ingredients);
            RemoveIngredients(currentRecipe, mappedRecipe.Ingredients);

            this.context.Update(currentRecipe);
            this.context.SaveChanges();
        }

        private void UpdateExistingIngredients(
            ICollection<RecipeIngredientEntity> existingIngredients, 
            ICollection<RecipeIngredientEntity> updatedIngredients)
        {        
            var matchingIngredients = updatedIngredients.Where(x => existingIngredients.Select(i => i.IngredientId).Contains(x.IngredientId));

            // Update any changes to ingredients that match existing ingredients for recipe
            foreach (var ingredient in matchingIngredients)
            {
                var existingIngredient = existingIngredients.Where(x => x.IngredientId == ingredient.IngredientId).FirstOrDefault();

                if (existingIngredient != null)
                {
                    // TODO: Update directly on this.context.RecipeIngredients
                    existingIngredient.Measurement = ingredient.Measurement;
                    existingIngredient.Amount = ingredient.Amount;
                }
            }
        }

        private void AddNewIngredients(
            RecipeEntity recipe,
            ICollection<RecipeIngredientEntity> ingredients)
        {
            var ingredientsToAdd = ingredients.Where(x => x.IngredientId == 0);

            var newIngredients = this.mapper.Map<IEnumerable<RecipeIngredientEntity>>(ingredientsToAdd);

            foreach (var ingredient in newIngredients)
            {
                recipe.Ingredients.Add(ingredient);
            }
        }

        private void RemoveIngredients(
            RecipeEntity recipe,
            ICollection<RecipeIngredientEntity> updatedIngredients)
        {
            var ingredientsToRemove = recipe.Ingredients.Where(x => !updatedIngredients.Select(u => u.Id).Contains(x.Id));
            
            foreach (var ingredient in ingredientsToRemove)
            {
                recipe.Ingredients.Remove(ingredient);
            }
        }
    }
}

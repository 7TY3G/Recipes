using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Recipes.Data.DataModels;
using Recipes.Domain.Entities;
using Recipes.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Recipes.Data.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly RecipesContext context;
        private readonly IMapper mapper;
        private const int favouritesCount = 3;

        public RecipeRepository(RecipesContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IEnumerable<RecipeModel> GetAllRecipes()
        {
            var recipes = this.context.Recipe.AsEnumerable();
            return mapper.Map<List<RecipeModel>>(recipes.ToList());
        }

        public IEnumerable<RecipeModel> GetFavouriteRecipes()
        {
            var recipes = this.context.Recipe.OrderByDescending(x => x.Rating).Take(favouritesCount).AsEnumerable();
            return mapper.Map<List<RecipeModel>>(recipes.ToList());
        }

        public RecipeModel GetById(int id)
        {
            var recipe = this.context.Recipe
                .Include(x => x.Ingredients)
                .ThenInclude(i => i.Ingredient)
                .SingleOrDefault(x => x.Id == id);

            if (recipe != null)
            {
                return mapper.Map<RecipeModel>(recipe);
            }

            return null;
        }

        public void AddRecipe(RecipeModel recipe)
        {
            var mappedRecipe = mapper.Map<Recipe>(recipe);

            this.context.Recipe.Update(mappedRecipe);
            this.context.SaveChanges();
        }

        public void UpdateRecipe(RecipeModel recipe)
        {
            var mappedRecipe = mapper.Map<Recipe>(recipe);

            var currentRecipe = this.context.Recipe
                .Include(x => x.Ingredients)
                .FirstOrDefault(x => x.Id == recipe.Id);

            if (currentRecipe != null)
            {
                currentRecipe.Name = mappedRecipe.Name;
                currentRecipe.Rating = mappedRecipe.Rating;

                UpdateExistingRecipeIngredients(currentRecipe.Ingredients, mappedRecipe.Ingredients.Where(x => x.Id != 0).ToList());
                AddNewIngredientsToRecipe(currentRecipe, mappedRecipe.Ingredients.Where(x => x.Id == 0).ToList());

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

        private void AddNewIngredientsToRecipe(Recipe currentRecipe, ICollection<RecipeIngredient> ingredients)
        {
            foreach (var ingredient in ingredients)
            {
                Ingredient ingredientToAdd = GetOrCreateIngredient(ingredient);

                var newRecipeIngredient = new RecipeIngredient()
                {
                    RecipeId = currentRecipe.Id,
                    Amount = ingredient.Amount,
                    Measurement = ingredient.Measurement,
                    IngredientId = ingredientToAdd != null ? ingredientToAdd.Id : 0
                };

                currentRecipe.Ingredients.Add(newRecipeIngredient);
            }
        }

        private Ingredient GetOrCreateIngredient(RecipeIngredient ingredient)
        {
            var ingredientToAdd = this.context.Ingredient.Where(x => x.Name == ingredient.Ingredient.Name).FirstOrDefault();

            if (ingredientToAdd == null)
            {
                ingredientToAdd = new Ingredient() { Name = ingredient.Ingredient.Name };
                this.context.Ingredient.Add(ingredientToAdd);
            }

            return ingredientToAdd;
        }
    }
}

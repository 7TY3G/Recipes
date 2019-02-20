using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Recipes.Data.DataModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Recipes.Data.Seeding
{
    public class DbSeeder
    {
        private readonly RecipesContext context;

        public DbSeeder(RecipesContext context)
        {
            this.context = context;
        }

        public void Seed()
        {
            this.context.Database.EnsureCreated();

            var currentDir = Environment.CurrentDirectory;

            if (!this.context.Ingredient.Any())
            {
                var ingredientsFile = string.Format("{0}\\../Recipes.Data/Seeding/Data/Ingredients.json", currentDir);
                var ingredientsJson = File.ReadAllText(ingredientsFile);
                var ingredients = JsonConvert.DeserializeObject<IEnumerable<Ingredient>>(ingredientsJson);

                this.context.Ingredient.AddRange(ingredients);
            }

            if (!this.context.Recipe.Any())
            {
                var recipesFile = string.Format("{0}\\../Recipes.Data/Seeding/Data/Recipes.json", currentDir);
                var recipesJson = File.ReadAllText(recipesFile);
                var recipes = JsonConvert.DeserializeObject<IEnumerable<Recipe>>(recipesJson);

                this.context.Recipe.AddRange(recipes);
            }

            this.context.SaveChanges();

            UpdateRecipeIngredients();
        }

        private void UpdateRecipeIngredients()
        {
            var recipes = this.context.Recipe.Include(x => x.Ingredients).AsEnumerable();
            var ingredients = this.context.Ingredient.AsEnumerable();

            var chickenTikka = recipes.Where(x => x.Name == "Chicken Tikka Masala").FirstOrDefault();

            if (chickenTikka.Ingredients.Count == 0)
            {
                chickenTikka.Ingredients = new List<RecipeIngredient>()
                {
                    new RecipeIngredient() { RecipeId = chickenTikka.Id, IngredientId = ingredients.Where(x => x.Name == "Chicken breasts").FirstOrDefault().Id, Amount = 400, Measurement = "Grams" },
                    new RecipeIngredient() { RecipeId = chickenTikka.Id, IngredientId = ingredients.Where(x => x.Name == "Canned tomatoes").FirstOrDefault().Id, Amount = 400, Measurement = "Grams" },
                    new RecipeIngredient() { RecipeId = chickenTikka.Id, IngredientId = ingredients.Where(x => x.Name == "Onion").FirstOrDefault().Id, Amount = 2 },
                    new RecipeIngredient() { RecipeId = chickenTikka.Id, IngredientId = ingredients.Where(x => x.Name == "Curry paste").FirstOrDefault().Id, Amount = 6, Measurement = "Tbsp" },
                    new RecipeIngredient() { RecipeId = chickenTikka.Id, IngredientId = ingredients.Where(x => x.Name == "Red peppers").FirstOrDefault().Id, Amount = 2 },
                    new RecipeIngredient() { RecipeId = chickenTikka.Id, IngredientId = ingredients.Where(x => x.Name == "Double cream").FirstOrDefault().Id, Amount = 150, Measurement = "Ml" },
                    new RecipeIngredient() { RecipeId = chickenTikka.Id, IngredientId = ingredients.Where(x => x.Name == "Butter").FirstOrDefault().Id, Amount = 25, Measurement = "Grams" }
                };
            }

            var chilli = recipes.Where(x => x.Name == "Chilli Con Carne").FirstOrDefault();

            if (chilli.Ingredients.Count == 0)
            {
                chilli.Ingredients = new List<RecipeIngredient>()
                {
                    new RecipeIngredient() { RecipeId = chilli.Id, IngredientId = ingredients.Where(x => x.Name == "Onion").FirstOrDefault().Id, Amount = 1 },
                    new RecipeIngredient() { RecipeId = chilli.Id, IngredientId = ingredients.Where(x => x.Name == "Red peppers").FirstOrDefault().Id, Amount = 1 },
                    new RecipeIngredient() { RecipeId = chilli.Id, IngredientId = ingredients.Where(x => x.Name == "Garlic").FirstOrDefault().Id, Amount = 2 },
                    new RecipeIngredient() { RecipeId = chilli.Id, IngredientId = ingredients.Where(x => x.Name == "Paprika").FirstOrDefault().Id, Amount = 1, Measurement = "Tsp" },
                    new RecipeIngredient() { RecipeId = chilli.Id, IngredientId = ingredients.Where(x => x.Name == "Cumin").FirstOrDefault().Id, Amount = 1, Measurement = "Tsp" },
                    new RecipeIngredient() { RecipeId = chilli.Id, IngredientId = ingredients.Where(x => x.Name == "Minced beef").FirstOrDefault().Id, Amount = 500, Measurement = "Grams" },
                    new RecipeIngredient() { RecipeId = chilli.Id, IngredientId = ingredients.Where(x => x.Name == "Canned tomatoes").FirstOrDefault().Id, Amount = 400, Measurement = "Grams" },
                    new RecipeIngredient() { RecipeId = chilli.Id, IngredientId = ingredients.Where(x => x.Name == "Red beans").FirstOrDefault().Id, Amount = 410, Measurement = "Grams" },
                    new RecipeIngredient() { RecipeId = chilli.Id, IngredientId = ingredients.Where(x => x.Name == "Rice").FirstOrDefault().Id, Amount = 300, Measurement = "Grams" }
                };
            }

            var bolognese = recipes.Where(x => x.Name == "Spagetti Bolognese").FirstOrDefault();

            if (bolognese.Ingredients.Count == 0)
            {
                bolognese.Ingredients = new List<RecipeIngredient>()
                {
                    new RecipeIngredient() { RecipeId = bolognese.Id, IngredientId = ingredients.Where(x => x.Name == "Minced beef").FirstOrDefault().Id, Amount = 500, Measurement = "Grams" },
                    new RecipeIngredient() { RecipeId = bolognese.Id, IngredientId = ingredients.Where(x => x.Name == "Garlic").FirstOrDefault().Id, Amount = 2 },
                    new RecipeIngredient() { RecipeId = bolognese.Id, IngredientId = ingredients.Where(x => x.Name == "Spagetti").FirstOrDefault().Id, Amount = 400, Measurement = "Grams" },
                    new RecipeIngredient() { RecipeId = bolognese.Id, IngredientId = ingredients.Where(x => x.Name == "Canned tomatoes").FirstOrDefault().Id, Amount = 400, Measurement = "Grams" },
                    new RecipeIngredient() { RecipeId = bolognese.Id, IngredientId = ingredients.Where(x => x.Name == "Basil").FirstOrDefault().Id, Amount = 1, Measurement = "Tsp" },
                    new RecipeIngredient() { RecipeId = bolognese.Id, IngredientId = ingredients.Where(x => x.Name == "Oregano").FirstOrDefault().Id, Amount = 1, Measurement = "Tsp" },
                    new RecipeIngredient() { RecipeId = bolognese.Id, IngredientId = ingredients.Where(x => x.Name == "Onion").FirstOrDefault().Id, Amount = 1 },
                };
            }

            var pudding = recipes.Where(x => x.Name == "Sticky Toffee Pudding").FirstOrDefault();

            if (pudding.Ingredients.Count == 0)
            {
                pudding.Ingredients = new List<RecipeIngredient>()
                {
                    new RecipeIngredient() { RecipeId = pudding.Id, IngredientId = ingredients.Where(x => x.Name == "Dates").FirstOrDefault().Id, Amount = 225, Measurement = "Grams" },
                    new RecipeIngredient() { RecipeId = pudding.Id, IngredientId = ingredients.Where(x => x.Name == "Vanilla extract").FirstOrDefault().Id, Amount = 1, Measurement = "Tsp" },
                    new RecipeIngredient() { RecipeId = pudding.Id, IngredientId = ingredients.Where(x => x.Name == "Self-raising flour").FirstOrDefault().Id, Amount = 175, Measurement = "Grams" },
                    new RecipeIngredient() { RecipeId = pudding.Id, IngredientId = ingredients.Where(x => x.Name == "Bicarbonate of soda").FirstOrDefault().Id, Amount = 1, Measurement = "Tsp" },
                    new RecipeIngredient() { RecipeId = pudding.Id, IngredientId = ingredients.Where(x => x.Name == "Eggs").FirstOrDefault().Id, Amount = 2 },
                    new RecipeIngredient() { RecipeId = pudding.Id, IngredientId = ingredients.Where(x => x.Name == "Butter").FirstOrDefault().Id, Amount = 85, Measurement = "Grams" },
                    new RecipeIngredient() { RecipeId = pudding.Id, IngredientId = ingredients.Where(x => x.Name == "Demerara sugar").FirstOrDefault().Id, Amount = 140, Measurement = "Grams" },
                    new RecipeIngredient() { RecipeId = pudding.Id, IngredientId = ingredients.Where(x => x.Name == "Black treacle").FirstOrDefault().Id, Amount = 2, Measurement = "Tbsp" },
                    new RecipeIngredient() { RecipeId = pudding.Id, IngredientId = ingredients.Where(x => x.Name == "Milk").FirstOrDefault().Id, Amount = 100, Measurement = "Ml" },
                    new RecipeIngredient() { RecipeId = pudding.Id, IngredientId = ingredients.Where(x => x.Name == "Custard").FirstOrDefault().Id, Amount = 1 },
                    new RecipeIngredient() { RecipeId = pudding.Id, IngredientId = ingredients.Where(x => x.Name == "Light muscovado sugar").FirstOrDefault().Id, Amount = 175, Measurement = "Grams" },
                    new RecipeIngredient() { RecipeId = pudding.Id, IngredientId = ingredients.Where(x => x.Name == "Butter").FirstOrDefault().Id, Amount = 50, Measurement = "Grams" },
                    new RecipeIngredient() { RecipeId = pudding.Id, IngredientId = ingredients.Where(x => x.Name == "Double cream").FirstOrDefault().Id, Amount = 225, Measurement = "Ml" },
                    new RecipeIngredient() { RecipeId = pudding.Id, IngredientId = ingredients.Where(x => x.Name == "Black treacle").FirstOrDefault().Id, Amount = 1, Measurement = "Tbsp" },
                };
            }

            this.context.SaveChanges();

        }
    }
}

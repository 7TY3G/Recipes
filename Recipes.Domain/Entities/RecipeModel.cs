using System.Collections.Generic;

namespace Recipes.Domain.Entities
{
    public class RecipeModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Rating { get; set; }

        public ICollection<IngredientModel> Ingredients { get; set; }
    }
}

using System.Collections.Generic;

namespace Recipes.Domain.Entities
{
    public class Recipe : BaseEntity
    {
        public string Name { get; set; }

        public double Rating { get; set; }

        public List<RecipeIngredient> Ingredients { get; set; }
    }
}

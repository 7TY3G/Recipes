using System.Collections.Generic;

namespace Recipes.Data.DataModels
{
    public class Recipe : BaseEntity
    {
        public string Name { get; set; }

        public double Rating { get; set; }

        public ICollection<RecipeIngredient> Ingredients { get; set; }
    }
}

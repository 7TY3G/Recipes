using System.Collections.Generic;

namespace Recipes.Domain.Entities
{
    public class Recipe
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Rating { get; set; }

        public ICollection<Ingredient> Ingredients { get; set; }

        public ICollection<MethodStep> Method { get; set; }
    }
}

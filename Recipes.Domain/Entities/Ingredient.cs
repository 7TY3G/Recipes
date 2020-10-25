namespace Recipes.Domain.Entities
{
    public class Ingredient
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Amount { get; set; }

        public string Measurement { get; set; }

        public int RecipeId { get; set; }

        public int IngredientId { get; set; }
    }
}

namespace Recipes.Data.DataModels
{
    public class RecipeIngredient : BaseEntity
    {
        public int RecipeId { get; set; }

        public int IngredientId { get; set; }

        public Ingredient Ingredient { get; set; }

        public double Amount { get; set; }

        public string Measurement { get; set; }
    }
}

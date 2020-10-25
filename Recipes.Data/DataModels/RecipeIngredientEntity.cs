using System.ComponentModel.DataAnnotations.Schema;

namespace Recipes.Data.DataModels
{
    [Table("RecipeIngredient")]
    public class RecipeIngredientEntity : BaseEntity
    {
        [ForeignKey("RecipeId")]
        public int RecipeId { get; set; }

        public int IngredientId { get; set; }

        [ForeignKey("IngredientId")]
        public IngredientEntity Ingredient { get; set; }

        public double Amount { get; set; }

        public string Measurement { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;

namespace Recipes.Data.DataModels
{
    [Table("Ingredient")]
    public class IngredientEntity : BaseEntity
    {
        public string Name { get; set; }
    }
}

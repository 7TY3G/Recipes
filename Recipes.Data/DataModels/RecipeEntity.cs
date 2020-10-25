using Recipes.Data.DataModels.Security;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recipes.Data.DataModels
{
    [Table("Recipe")]
    public class RecipeEntity : BaseEntity
    {
        public string Name { get; set; }

        public double Rating { get; set; }

        [ForeignKey("RecipeId")]
        public ICollection<RecipeIngredientEntity> Ingredients { get; set; }
    }
}

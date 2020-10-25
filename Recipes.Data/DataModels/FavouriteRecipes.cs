using Recipes.Data.DataModels.Security;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recipes.Data.DataModels
{
    public class FavouriteRecipes : BaseEntity
    {
        public string UserId { get; set; }

        public User User { get; set; }

        public int RecipeId { get; set; }

        [ForeignKey("RecipeId")]
        public RecipeEntity Recipe { get; set; }
    }
}

using Recipes.Data.DataModels.Security;

namespace Recipes.Data.DataModels
{
    public class FavouriteRecipes : BaseEntity
    {
        public string UserId { get; set; }

        public User User { get; set; }

        public int RecipeId { get; set; }

        public Recipe Recipe { get; set; }
    }
}

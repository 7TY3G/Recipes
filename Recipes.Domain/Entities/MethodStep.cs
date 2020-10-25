namespace Recipes.Domain.Entities
{
    public class MethodStep
    {
        public int Id { get; set; }

        public int RecipeId { get; set; }

        public int Order { get; set; }

        public string Instructions { get; set; }
    }
}

using Microsoft.AspNetCore.Mvc;
using Recipes.Data.Repos;
using Recipes.Domain.Entities;

namespace Recipes.Web.Controllers
{
    [Route("api/[controller]")]
    public class RecipeController : Controller
    {
        private readonly IRecipeRepository recipeRepo;

        public RecipeController(IRecipeRepository recipeRepo)
        {
            this.recipeRepo = recipeRepo;
        }

        [HttpPost("Add")]
        public IActionResult Index([FromBody]Recipe recipe)
        {
            this.recipeRepo.AddRecipe(recipe);

            return Ok();
        }
    }
}
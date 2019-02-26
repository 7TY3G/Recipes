using Microsoft.AspNetCore.Mvc;
using Recipes.Data.Repos;

namespace Recipes.Web.Controllers
{
    [Route("api/[controller]")]
    public class RecipesListController : ControllerBase
    {
        private readonly IRecipeRepository recipeRepo;

        public RecipesListController(IRecipeRepository recipeRepo)
        {
            this.recipeRepo = recipeRepo;
        }

        [HttpGet("[action]")]
        public IActionResult Get()
        {
            var recipes = this.recipeRepo.GetAllRecipes();
            return Ok(recipes);
        }

        [HttpGet("Favourites")]
        public IActionResult GetFavourites()
        {
            var recipes = this.recipeRepo.GetFavouriteRecipes();
            return Ok(recipes);
        }
    }
}
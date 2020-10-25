using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Recipes.Domain.Repositories;
using System;

namespace Recipes.Web.Controllers
{
    [Route("api/[controller]")]
    public class RecipesListController : ControllerBase
    {
        private readonly ILogger<RecipesListController> logger;
        private readonly IRecipeRepository recipeRepo;

        public RecipesListController(ILogger<RecipesListController> logger, IRecipeRepository recipeRepo)
        {
            this.logger = logger;
            this.recipeRepo = recipeRepo;
        }

        [HttpGet("[action]")]
        public IActionResult Get()
        {
            logger.LogInformation("Get RecipesList");

            try
            {
                var recipes = this.recipeRepo.GetAllRecipes();
                return Ok(recipes);
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex.ToString());
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Favourites")]
        public IActionResult GetFavourites()
        {
            logger.LogInformation("GetFavourites RecipesList");
            var recipes = this.recipeRepo.GetFavouriteRecipes();
            return Ok(recipes);
        }
    }
}
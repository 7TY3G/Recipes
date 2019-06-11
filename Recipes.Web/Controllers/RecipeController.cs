using Microsoft.AspNetCore.Mvc;
using Recipes.Domain.Repositories;
using Recipes.Domain.Entities;

namespace Recipes.Web.Controllers
{
    [Route("api/[controller]")]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeRepository recipeRepo;

        public RecipeController(IRecipeRepository recipeRepo)
        {
            this.recipeRepo = recipeRepo;
        }

        [HttpPost("Add")]
        public IActionResult Add([FromBody]RecipeModel recipe)
        {
            this.recipeRepo.AddRecipe(recipe);

            return Ok();
        }

        [HttpPut("Update")]
        public IActionResult Update([FromBody]RecipeModel recipe)
        {
            this.recipeRepo.UpdateRecipe(recipe);

            return Ok(recipe);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            var recipe = this.recipeRepo.GetById(id);

            return Ok(recipe);
        }
    }
}
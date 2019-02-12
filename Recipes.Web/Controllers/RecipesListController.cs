using Microsoft.AspNetCore.Mvc;
using Recipes.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Recipes.Web.Controllers
{
    [Route("api/[controller]")]
    public class RecipesListController : Controller
    {
        private static List<Recipe> Recipes = new List<Recipe>()
        {
            new Recipe { Name = "Chilli Con Carne", Rating = 3 },
            new Recipe { Name = "Spagetti Bolognese", Rating = 5 },
            new Recipe { Name = "Chicken Tikka Masala", Rating = 4.5 },
            new Recipe { Name = "Sausage Casserole", Rating = 4.2 } 
        };

        [HttpGet("[action]")]
        public IActionResult Get()
        {
            return Ok(Recipes);
        }

        [HttpGet("Favourites")]
        public IActionResult GetFavourites()
        {
            var topRecipes = Recipes.Take(3);
            return Ok(topRecipes);
        }
    }
}
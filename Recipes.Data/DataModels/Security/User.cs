using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Recipes.Data.DataModels.Security
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime JoinDate { get; set; }

        public ICollection<FavouriteRecipes> FavouriteRecipes { get; set; }
    }
}

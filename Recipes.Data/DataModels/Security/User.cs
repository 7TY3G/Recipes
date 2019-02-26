using Microsoft.AspNetCore.Identity;
using System;

namespace Recipes.Data.DataModels.Security
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime JoinDate { get; set; }
    }
}

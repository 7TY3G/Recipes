using Microsoft.AspNetCore.Identity;

namespace Recipes.Data.DataModels.Security
{
    public class Role : IdentityRole
    {
        public string Description { get; set; }
    }
}

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Recipes.Data.DataModels.Security;
using Recipes.Domain.Entities;
using System.Threading.Tasks;

namespace Recipes.Web.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;

        public AccountController(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        [HttpGet("Login")]
        public IActionResult Login()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                // TODO: Redirect automatically to home page
                return StatusCode(500);
            }

            return Ok();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody]UserModel user)
        {
            var result = await signInManager.PasswordSignInAsync(user.Username, user.Password, false, false);

            if (result.Succeeded)
            {
                return Ok();
            }

            // TODO: Redirect to login page
            return StatusCode(500);
        }

        [HttpGet("Logout")]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return Ok();
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody]UserModel user)
        {
            // TODO: Move to business logic layer and add mapping
            var userToCreate = new User()
            {
                FirstName = user.Firstname,
                LastName = user.Lastname,
                UserName = user.Username,
                Email = user.Email
            };

            var result = await userManager.CreateAsync(userToCreate, user.Password);

            if (result.Succeeded)
            {
                var isSignedIn = await signInManager.PasswordSignInAsync(user.Username, user.Password, false, false);

                if (isSignedIn.Succeeded)
                {
                    return Ok();
                }
            }

            // Redirect to registration page
            return StatusCode(500);
        }
    }
}
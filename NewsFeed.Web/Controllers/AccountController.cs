using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NewsFeed.Web.ViewModels.Account;
using System.Linq;
using System.Threading.Tasks;

namespace NewsFeed.Web.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;

        public AccountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            var model = new LoginViewModel
            {
                Login = "admin",
                Password = "admin"
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            //  friendly auth with no password validation just to test it out
            var user = await userManager.FindByNameAsync(model.Login);
            if (user == null)
            {
                user = new IdentityUser(model.Login);
                var result = await userManager.CreateAsync(user);
                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", string.Join(" | ", result.Errors.Select(e => e.Description)));
                    return View(model);
                }
            }

            await signInManager.SignInAsync(user, model.RememberMe);
            return Redirect(returnUrl);
        }

        public async Task<ActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return Redirect(Url.Content("~/"));
        }
        
    }
}

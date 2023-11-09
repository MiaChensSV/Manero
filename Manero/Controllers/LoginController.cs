using Manero.Models.Entities;
using Manero.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Manero.Controllers
{
    public class LoginController : Controller
    {
        private readonly UserManager<AppIdentityUser> _userManager;
        private readonly SignInManager<AppIdentityUser> _signInManager;

        public LoginController(UserManager<AppIdentityUser> userManager, SignInManager<AppIdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                ModelState.AddModelError("", "You have entered an invalid username or password!");
                return View(model);
            }

            var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, lockoutOnFailure: false);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "You have entered an invalid username or password!");
                return View(model);
            }

            // Since returnUrl is not used, simply redirect to the home page
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Index()
        {
            // No need to pass a returnUrl to the view model
            return View(new LoginViewModel());
        }
    }
}

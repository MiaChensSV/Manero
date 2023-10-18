using Microsoft.AspNetCore.Mvc;

namespace Manero.Controllers
{
    public class OnboardingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

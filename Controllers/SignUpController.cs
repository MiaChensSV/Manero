using Microsoft.AspNetCore.Mvc;

namespace Manero.Controllers
{
    public class SignUpController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Verify()
        {
            return View();
        }

        public IActionResult Otp()
        {
            return View();
        }
    }
}

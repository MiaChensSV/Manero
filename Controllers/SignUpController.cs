using Microsoft.AspNetCore.Mvc;

namespace Manero.Controllers
{
    public class SignUpController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

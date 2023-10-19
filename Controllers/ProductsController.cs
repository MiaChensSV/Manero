using Microsoft.AspNetCore.Mvc;

namespace Manero.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

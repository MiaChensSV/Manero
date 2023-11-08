using Microsoft.AspNetCore.Mvc;

namespace Manero.Controllers
{
    public class CheckOutController : Controller
    {
        public IActionResult Order()
        {
            return View();
        }


        public IActionResult OrderFailed()
        {

            return View();
        }

    }

}

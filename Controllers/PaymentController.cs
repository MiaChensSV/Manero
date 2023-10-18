using Microsoft.AspNetCore.Mvc;

namespace Manero.Controllers;

public class PaymentController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}

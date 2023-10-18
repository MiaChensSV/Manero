using Microsoft.AspNetCore.Mvc;

namespace Manero.Controllers;

public class AccountController : Controller
{
    public IActionResult Index()
    {
        return View();
    }


	public IActionResult MyAccount()
	{

		return View();
	}

    public IActionResult Edit()
    {

        return View();
    }
    public IActionResult Orders()
    {

        return View();
    }
}

   



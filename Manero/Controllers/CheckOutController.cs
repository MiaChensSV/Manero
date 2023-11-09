using Manero.Services;
using Manero.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Manero.Controllers
{
    public class CheckOutController : Controller
    {
        private readonly CheckOutService _checkOutService;

        public CheckOutController(CheckOutService checkOutService)
        {
            _checkOutService = checkOutService;
        }


        public IActionResult Order()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Order(CheckOutViewModel viewModel)
        {
            if(ModelState.IsValid)
            {
				var order = await _checkOutService.RegisterAsync(viewModel);
				if (order != null)
				{

					return RedirectToAction("Order");
                }
                else
                {
                    ModelState.AddModelError("", ModelState.ValidationState.ToString());
                    return RedirectToAction("OrderFailed");
                }

			}
            return View("OrderFailed");
           

            
        }
        public IActionResult OrderFailed()
        {
            return View();
        }


    }
}

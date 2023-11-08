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
            return View(new CheckOutViewModel());

            //Vänta på Mia
        }


        [HttpPost]
        public async Task<IActionResult> PlaceOrder(CheckOutViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {

                return View("Order", viewModel);
            }

            try
            {
                var order = await _checkOutService.RegisterAsync(viewModel);

                if (order != null)
                {

                    return View("OrderSuccess", order);
                }
                else
                {

                    return View("OrderFailed");
                }
            }
            catch
            {

                return View("OrderFailed");
            }
        }
        public IActionResult OrderFailed()
        {
            return View();
        }


    }
}

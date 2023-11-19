using Manero.Services;
using Manero.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Manero.Controllers
{
    public class CheckOutController : Controller
    {
        private readonly CheckOutService _checkOutService;

        public CheckOutController(CheckOutService checkOutService)
        {
            _checkOutService = checkOutService;
        }


        public IActionResult OrderSucess()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            // await _checkOutService.GetCheckoutAsync();
            return RedirectToAction("Checkout", "ShopingCart");
        }

        [HttpPost]
        public async Task<IActionResult> Index(CheckOutViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var userId = GetUserId();
                viewModel.UserId = userId;
                var articleNumber = viewModel.ArticleNumber;
                var order = await _checkOutService.RegisterAsync(viewModel);
                if (order != null)
                {

                    return RedirectToAction("OrderSucess");
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

        private string GetUserId()
        {
            string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
                return "";
            else
                return userId;
        }
    }
}

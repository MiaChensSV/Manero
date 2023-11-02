using Manero.Services;
using Microsoft.AspNetCore.Mvc;

namespace Manero.Controllers
{
    public class CartController : Controller
    {

        private readonly CartService _cartService;

       
        public CartController(CartService cartService)
        {
            _cartService = cartService;
        }

        public async Task<IActionResult> Index()
        {
            // Get the details of products in the cart
            var cartProductDetails = await _cartService.GetCartProductDetailsAsync();

            return View(cartProductDetails);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(string articleNumber)
        {

            articleNumber = "1!";
            await _cartService.AddToCart(articleNumber);

            return RedirectToAction("Index", "Cart");



        }


    }
}

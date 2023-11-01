using Manero.Repository;
using Manero.Services;
using Manero.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Manero.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductListService _productService;

        public ProductsController(ProductListService productService)
        {
            _productService = productService;
        }

        public async Task <IActionResult> Index()
        {
            var viewModel = new AllProductsViewModel
            {

                Title = "Bestsellers",
                AllProducts = await _productService.GetAllProductsAsync(),
                AllReviews = await _productService.GetAllReviewssAsync()
 

            };

            return View(viewModel);
        }

        public IActionResult Details()
        {
            return View();
        }

        public IActionResult Reviews() 
        {
            return View();
        }

        public IActionResult FilterProduct()
        {
            return View();
        }
    }
}

using Manero.Models.Dtos;
using Manero.Repository;
using Manero.Services;
using Manero.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace Manero.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductListService _productService;
 
        private readonly ProductDetailsService _productDetailsService;

        public ProductsController(IProductListService productService, ProductDetailsService productDetailsService )
        {
            _productService = productService;
      
            _productDetailsService = productDetailsService;
        }

        public async Task <IActionResult> Index()
        {
            var viewModel = new AllProductsViewModel
            {

                Title = "Bestsellers",
                AllProducts = await _productService.GetAllProductsAsync(),
              
 

            };

            return View(viewModel);
        }

        [HttpGet("product/{id}")]
        public async Task<IActionResult> Details(int id)
        {
            ProductProductDetail product = await _productDetailsService.GetProductDetailByIdAsync(id);

            return View(product);
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


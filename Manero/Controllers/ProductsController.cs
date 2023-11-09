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
        private readonly ProductDetailsRepo _productDetailrepo;

        public ProductsController(IProductListService productService, ProductDetailsRepo productDetailsRepo)
        {
            _productService = productService;
            _productDetailrepo = productDetailsRepo;
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
            ProductProductDetail product = await _productDetailrepo.GetAsync(x => x.ProductId == id);

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


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
        private readonly ProductListService _productService;
        private readonly ProductDetailsService _productDetailService;

        public ProductsController(ProductListService productService, ProductDetailsService productDetailService)
        {
            _productService = productService;
            _productDetailService = productDetailService;
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

        [HttpGet("product/{id}")]
        public async Task<IActionResult> Details(int articlenumber)
        {
            
            // Fetch the product detail entity
            var productDetailEntity = await _productDetailService.GetProductDetailAsync(articlenumber);

            if (productDetailEntity != null)
            {
                // Convert the entity to a DTO using the implicit operator
                var productDetailDto = (ProductProductDetail)productDetailEntity;

                // Create a view model and populate it with the DTO
                var viewModel = new ProductDetailsViewModel
                {
                    Product = productDetailDto
                };

                return View(viewModel);
            }
            else
            {
                // Handle the case where the product with the given id is not found
                return NotFound();
            }
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


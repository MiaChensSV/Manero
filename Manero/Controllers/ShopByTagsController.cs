using Manero.Context;
using Manero.Repository;
using Manero.Services;
using Manero.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Manero.Controllers
{
    public class ShopByTagsController : Controller
    {
        private readonly ProductListService _service;


        public ShopByTagsController(ShopByTagsRepo repo, ProductListService service)
        {
           
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task <IActionResult> ProductListByTagNameKids()
        {
            var viewModel = new ProductsByTagsViewModel
            {

                Title = "Shop By Tags",
                TagTitle = "Kids",
                ProductByTagName = await _service.GetAllByTagNameAsync("Kids")


            };
           
            return View(viewModel);
        }

        public async Task<IActionResult> ProductListByTagNamePants()
        {
            var viewModel = new ProductsByTagsViewModel
            {

                Title = "Shop By Tags",
                TagTitle = "Pants",
                ProductByTagName = await _service.GetAllByTagNameAsync("Pants")


            };

            return View(viewModel);
        }

        public async Task<IActionResult> ProductListByTagNameAccessories()
        {
            var viewModel = new ProductsByTagsViewModel
            {

                Title = "Shop By Tags",
                TagTitle = "Accessories",
                ProductByTagName = await _service.GetAllByTagNameAsync("Accessories")


            };

            return View(viewModel);
        }

        public async Task<IActionResult> ProductListByTagNameDresses()
        {
            var viewModel = new ProductsByTagsViewModel
            {

                Title = "Shop By Tags",
                TagTitle = "Dresses",
                ProductByTagName = await _service.GetAllByTagNameAsync("Dresses")


            };

            return View(viewModel);
        }
        public async Task<IActionResult> ProductListByTagNameMen()
        {
            var viewModel = new ProductsByTagsViewModel
            {

                Title = "Shop By Tags",
                TagTitle = "Men",
                ProductByTagName = await _service.GetAllByTagNameAsync("Men")


            };

            return View(viewModel);
        }
        public async Task<IActionResult> ProductListByTagNameWomen()
        {
            var viewModel = new ProductsByTagsViewModel
            {

                Title = "Shop By Tags",
                TagTitle = "Women",
                ProductByTagName = await _service.GetAllByTagNameAsync("Women")


            };

            return View(viewModel);
        }
        public async Task<IActionResult> ProductListByTagNameShoes()
        {
            var viewModel = new ProductsByTagsViewModel
            {

                Title = "Shop By Tags",
                TagTitle = "Shoes",
                ProductByTagName = await _service.GetAllByTagNameAsync("Shoes")


            };

            return View(viewModel);
        }
        public async Task<IActionResult> ProductListByTagNameTShirts()
        {
            var viewModel = new ProductsByTagsViewModel
            {

                Title = "Shop By Tags",
                TagTitle = "T-Shirt",
                ProductByTagName = await _service.GetAllByTagNameAsync("T-Shirt")


            };

            return View(viewModel);
        }
    }
}

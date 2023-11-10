using Manero.Controllers;
using Manero.Models.Dtos;
using Manero.Repository;
using Manero.Services;
using Manero.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Manero.Test
{
    /*
    public class ProductController_Tests
    {
       
        private readonly Mock<IProductListService> _productListService;
        private readonly ProductsController _productsController;

        public ProductController_Tests()
        {
            _productListService = new Mock<IProductListService>();
            _productsController = new ProductsController(_productListService.Object);

           
        }


        [Fact]
        public async Task ProductsController_Index_ShouldReturnViewModel()
        {
            // Arrange
            _productListService.Setup(service => service.GetAllProductsAsync()).ReturnsAsync(new List<ProductProductList>

        {
            new ProductProductList
            {
                ArticleNumber = "123",
                ProductName = "En Produkt",
                Price = 999,
                Image = "bild.jpg",
               
            }
        });

            

            // Act
            var result = await _productsController.Index() as ViewResult;

            // Assert
            Assert.NotNull( result );

            var viewModel = result.Model as AllProductsViewModel;
            Assert.NotNull(viewModel);
            Assert.Equal("Bestsellers", viewModel.Title);
            Assert.NotNull(viewModel.AllProducts);
            

        }
        
       
    }*/
}

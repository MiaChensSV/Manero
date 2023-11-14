using Manero.Context;
using Manero.Controllers;
using Manero.Models.Dtos;
using Manero.Models.Entities;
using Manero.Repository;
using Manero.Services;
using Manero.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Linq.Expressions;

namespace Manero.Test
{
    
    public class ProductController_Tests
    {
      
        private readonly Mock<IProductListService> _productListService;
        private readonly ProductsController _productsController;
        private readonly ProductDetailsRepo _productDetailsRepo;

        public ProductController_Tests()
        {
          
            
            _productListService = new Mock<IProductListService>();
            
            _productsController = new ProductsController(_productListService.Object, _productDetailsRepo);

           
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
        // EMMAS TEST
        [Fact]
        public async Task ProductsController_Details_ShouldReturnViewWithProduct()
        {
            // Arrange
            int productId = 1;
            var product = new ProductProductDetail
            {
                ArticleNumber = "123",
                ProductTitle = "En Produkt",
                Price = 999,
                Image = "bild.jpg",
                
            };


            // Act
            var result = await _productsController.Details(productId) as ViewResult;

            // Assert
            Assert.NotNull(result);

            var viewModel = result.Model as ProductProductDetail;
            Assert.NotNull(viewModel);
            Assert.Equal(product.ArticleNumber, viewModel.ArticleNumber);
            Assert.Equal(product.ProductTitle, viewModel.ProductTitle);
            
        }
    }
    
}

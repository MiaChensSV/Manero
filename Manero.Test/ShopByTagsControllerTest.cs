using Manero.Controllers;
using Manero.Models.Dtos;
using Manero.Services;
using Manero.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manero.Test
{
    public class ShopByTagsController_Tests
    {
        private readonly Mock<IProductListService> _productListService;
        private readonly ShopByTagsController _shopByTagsController;

        public ShopByTagsController_Tests()
        {
            _productListService = new Mock<IProductListService>();
            _shopByTagsController = new ShopByTagsController(_productListService.Object);


        }


        [Fact]
        public void ShopByTagsController_Index_ShouldReturnViewResult()
        {
            // Arrange


            // Act
            var result = _shopByTagsController.Index() as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
        }


        [Fact]
        public async Task ShopByTagsController_ProductListByTagNameKids_ShouldReturnViewModel()
        {
            // Arrange
            _productListService.Setup(service => service.GetAllByTagNameAsync("Kids")).ReturnsAsync(new List<ProductProductList>

        {
            new ProductProductList
            {
                ArticleNumber = "321",
                ProductName = "Produkt 2",
                Price = 200,
                Image = "product.jpg"
               

            }
        });



            // Act
            var result = await _shopByTagsController.ProductListByTagNameKids() as ViewResult;

            // Assert
            Assert.NotNull(result);

            var viewModel = result.Model as ProductsByTagsViewModel;
            Assert.NotNull(viewModel);
            Assert.Equal("Shop By Tags", viewModel.Title);
            Assert.Equal("Kids", viewModel.TagTitle);
            Assert.NotNull(viewModel.ProductByTagName);


        }

        [Fact]
        public async Task ShopByTagsController_ProductListByTagNamePants_ShouldReturnViewModel()
        {
            // Arrange
            _productListService.Setup(service => service.GetAllByTagNameAsync("Pants")).ReturnsAsync(new List<ProductProductList>

        {
            new ProductProductList
            {
                ArticleNumber = "322",
                ProductName = "Produkt 134",
                Price = 349,
                Image = "product.jpg"


            }
        });



            // Act
            var result = await _shopByTagsController.ProductListByTagNamePants() as ViewResult;

            // Assert
            Assert.NotNull(result);

            var viewModel = result.Model as ProductsByTagsViewModel;
            Assert.NotNull(viewModel);
            Assert.Equal("Shop By Tags", viewModel.Title);
            Assert.Equal("Pants", viewModel.TagTitle);
            Assert.NotNull(viewModel.ProductByTagName);


        }

        [Fact]
        public async Task ShopByTagsController_ProductListByTagNameAccessories_ShouldReturnViewModel()
        {
            // Arrange
            _productListService.Setup(service => service.GetAllByTagNameAsync("Accessories")).ReturnsAsync(new List<ProductProductList>

        {
            new ProductProductList
            {
                ArticleNumber = "323",
                ProductName = "Produkt 14",
                Price = 799,
                Image = "product.jpg"


            }
        });



            // Act
            var result = await _shopByTagsController.ProductListByTagNameAccessories() as ViewResult;

            // Assert
            Assert.NotNull(result);

            var viewModel = result.Model as ProductsByTagsViewModel;
            Assert.NotNull(viewModel);
            Assert.Equal("Shop By Tags", viewModel.Title);
            Assert.Equal("Accessories", viewModel.TagTitle);
            Assert.NotNull(viewModel.ProductByTagName);


        }

        [Fact]
        public async Task ShopByTagsController_ProductListByTagNameDresses_ShouldReturnViewModel()
        {
            // Arrange
            _productListService.Setup(service => service.GetAllByTagNameAsync("Dresses")).ReturnsAsync(new List<ProductProductList>

        {
            new ProductProductList
            {
                ArticleNumber = "324",
                ProductName = "Produkt 22",
                Price = 400,
                Image = "product.jpg"


            }
        });



            // Act
            var result = await _shopByTagsController.ProductListByTagNameDresses() as ViewResult;

            // Assert
            Assert.NotNull(result);

            var viewModel = result.Model as ProductsByTagsViewModel;
            Assert.NotNull(viewModel);
            Assert.Equal("Shop By Tags", viewModel.Title);
            Assert.Equal("Dresses", viewModel.TagTitle);
            Assert.NotNull(viewModel.ProductByTagName);


        }

        [Fact]
        public async Task ShopByTagsController_ProductListByTagNameMen_ShouldReturnViewModel()
        {
            // Arrange
            _productListService.Setup(service => service.GetAllByTagNameAsync("Men")).ReturnsAsync(new List<ProductProductList>

        {
            new ProductProductList
            {
                ArticleNumber = "325",
                ProductName = "Produkt 7",
                Price = 800,
                Image = "product.jpg"


            }
        });



            // Act
            var result = await _shopByTagsController.ProductListByTagNameMen() as ViewResult;

            // Assert
            Assert.NotNull(result);

            var viewModel = result.Model as ProductsByTagsViewModel;
            Assert.NotNull(viewModel);
            Assert.Equal("Shop By Tags", viewModel.Title);
            Assert.Equal("Men", viewModel.TagTitle);
            Assert.NotNull(viewModel.ProductByTagName);


        }

        [Fact]
        public async Task ShopByTagsController_ProductListByTagNameWomen_ShouldReturnViewModel()
        {
            // Arrange
            _productListService.Setup(service => service.GetAllByTagNameAsync("Women")).ReturnsAsync(new List<ProductProductList>

        {
            new ProductProductList
            {
                ArticleNumber = "326",
                ProductName = "Produkt 127",
                Price = 249,
                Image = "product.jpg"


            }
        });



            // Act
            var result = await _shopByTagsController.ProductListByTagNameWomen() as ViewResult;

            // Assert
            Assert.NotNull(result);

            var viewModel = result.Model as ProductsByTagsViewModel;
            Assert.NotNull(viewModel);
            Assert.Equal("Shop By Tags", viewModel.Title);
            Assert.Equal("Women", viewModel.TagTitle);
            Assert.NotNull(viewModel.ProductByTagName);


        }

        [Fact]
        public async Task ShopByTagsController_ProductListByTagNameShoes_ShouldReturnViewModel()
        {
            // Arrange
            _productListService.Setup(service => service.GetAllByTagNameAsync("Shoes")).ReturnsAsync(new List<ProductProductList>

        {
            new ProductProductList
            {
                ArticleNumber = "327",
                ProductName = "Produkt 31",
                Price = 849,
                Image = "product.jpg"


            }
        });



            // Act
            var result = await _shopByTagsController.ProductListByTagNameShoes() as ViewResult;

            // Assert
            Assert.NotNull(result);

            var viewModel = result.Model as ProductsByTagsViewModel;
            Assert.NotNull(viewModel);
            Assert.Equal("Shop By Tags", viewModel.Title);
            Assert.Equal("Shoes", viewModel.TagTitle);
            Assert.NotNull(viewModel.ProductByTagName);


        }

        [Fact]
        public async Task ShopByTagsController_ProductListByTagNameTShirts_ShouldReturnViewModel()
        {
            // Arrange
            _productListService.Setup(service => service.GetAllByTagNameAsync("T-Shirt")).ReturnsAsync(new List<ProductProductList>

        {
            new ProductProductList
            {
                ArticleNumber = "327",
                ProductName = "Produkt 31",
                Price = 849,
                Image = "product.jpg"


            }
        });



            // Act
            var result = await _shopByTagsController.ProductListByTagNameTShirts() as ViewResult;

            // Assert
            Assert.NotNull(result);

            var viewModel = result.Model as ProductsByTagsViewModel;
            Assert.NotNull(viewModel);
            Assert.Equal("Shop By Tags", viewModel.Title);
            Assert.Equal("T-Shirts", viewModel.TagTitle);
            Assert.NotNull(viewModel.ProductByTagName);


        }
    }
}

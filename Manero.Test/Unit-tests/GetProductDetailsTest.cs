using Manero.Context;
using Manero.Controllers;
using Manero.Models.Dtos;
using Manero.Models.Entities;
using Manero.Repository;
using Manero.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Linq.Expressions;


namespace Manero.Test.Unit_tests;

 public class GetProductDetailsTest
{
    private readonly DataContext _context;
    private readonly Mock<IProductListService> _productListService;
    private readonly ProductsController _productsController;
    private readonly Mock<IProductDetailsRepo> _productDetailsRepo;
    private readonly ProductDetailsService _productDetailsService;

    public GetProductDetailsTest()
    {
        var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
        _context = new DataContext(options);
        _productListService = new Mock<IProductListService>();
        _productDetailsRepo = new Mock<IProductDetailsRepo>(); 
        _productDetailsService = new ProductDetailsService(_productDetailsRepo.Object, _context);
        _productsController = new ProductsController(_productListService.Object, _productDetailsService);
    }

    [Fact]
    public async Task GetProductDetailByIdAsync_ReturnsProductDetail_WhenIdIsValid()
    {
        // Arrange
        var testProductDetail = new ProductDetailEntity
        {
            ProductId = 1,
            ArticleNumber = "TestArticleNumber",
            ProductTitle = "TestProductTitle",
            ProductDetailDescription = "TestDescription",
            Price = 100,
            DiscountedPrice = 80,
            ProductImageUrl = "TestImageUrl",
            Color = new ProductColorEntity { ColorId = 1 },
            Size = new ProductSizeEntity { SizeId = 1 },
            Quantity = 10,
            ProductModel = new ProductModelEntity { Reviews = new List<ReviewEntity>() }
        };
        _productDetailsRepo.Setup(repo => repo.GetAsync(It.IsAny<Expression<Func<ProductDetailEntity, bool>>>()))
            .ReturnsAsync(testProductDetail);

        // Act
        var result = await _productDetailsService.GetProductDetailByIdAsync(testProductDetail.ProductId);

        // Assert
        Assert.Equal(1, result.ProductId);
        Assert.Equal("TestArticleNumber", result.ArticleNumber);
    }

    [Fact]
    public async Task ProductDetailsService_GetProductDetailByIdAsync_ShouldReturnNull_WhenProductDoesNotExist()
    {
        // Arrange
        var mockRepo = new Mock<IProductDetailsRepo>();
        var mockContext = new Mock<DataContext>();
        mockRepo.Setup(repo => repo.GetAsync(It.IsAny<Expression<Func<ProductDetailEntity, bool>>>()))
            .ReturnsAsync((ProductProductDetail)null);


        // Act
        var result = await _productDetailsService.GetProductDetailByIdAsync(1);

        // Assert
        Assert.Null(result);
    }
}

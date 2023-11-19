using Manero.Models.Dtos;
using Manero.Models.Entities;


namespace Manero.Test.Unit_tests
{
    public class ProductProductDetailShouldConvertToProductDetailEntity
    {
        [Fact]
        public void ProductProductDetailDhouldConvertToProductDetailEntity()
        {
            // Arrange
            var productProductDetail = new ProductProductDetail
            {
                ArticleNumber = "123",
                ProductTitle = "Test Product",
                Description = "Description",
                Price = 50.0m,
                DiscountedPrice = 45.0m,
                Image = "image_url",
                Reviews = new List<ReviewEntity>(),
                Color = 1,
                Size = 2,
                Quantity = 10
            };

            // Act
            ProductDetailEntity productDetailEntity = productProductDetail;

            // Assert
            Assert.NotNull(productDetailEntity);
            Assert.Equal(productProductDetail.ArticleNumber, productDetailEntity.ArticleNumber);
            Assert.Equal(productProductDetail.ProductTitle, productDetailEntity.ProductTitle);
            Assert.Equal(productProductDetail.Description, productDetailEntity.ProductDetailDescription);
            Assert.Equal(productProductDetail.Price, productDetailEntity.Price);
            Assert.Equal(productProductDetail.DiscountedPrice, productDetailEntity.DiscountedPrice);
            Assert.Equal(productProductDetail.Image, productDetailEntity.ProductImageUrl);
           
        }
    }

}


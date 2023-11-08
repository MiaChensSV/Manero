using Manero.Models.Entities;
using System.Diagnostics;

namespace Manero.Models.Dtos
{
    public class ProductProductDetail
    {
        public string ArticleNumber { get; set; } = null!;
        public string ProductTitle { get; set; } = null!;
        public string? Description { get; set; }
       
        public string? Image { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountedPrice { get; set; }    
        public string? Rating { get; set; }

        public IEnumerable<ReviewEntity>? Reviews { get; set; } = new List<ReviewEntity>();

        

        //make a function to get reviews from productmodel


        //Konverterar från ProductDetailEntity till ProductProductDetail
        public static implicit operator ProductProductDetail(ProductDetailEntity entity)
        {
            var productDetail = new ProductProductDetail
            {
                ArticleNumber = entity.ArticleNumber,
                ProductTitle = entity.ProductTitle,
                Description = entity.ProductDetailDescription,
                Price = entity.Price,
                DiscountedPrice = entity.DiscountedPrice,
                Image = entity.ProductImageUrl,
                Reviews = entity.ProductModel.Reviews,
              
            };
            return productDetail;
        }
        public static implicit operator ProductDetailEntity(ProductProductDetail product)
        {

            var entity = new ProductDetailEntity
            {
                ArticleNumber = product.ArticleNumber,
                ProductTitle = product.ProductTitle,
                ProductDetailDescription = product.Description,
                Price = product.Price,
                ProductImageUrl = product.Image,
            };
            return entity;
        }

    }
}

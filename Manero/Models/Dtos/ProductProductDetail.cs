using Manero.Models.Entities;
using System.Diagnostics;

namespace Manero.Models.Dtos
{
    public class ProductProductDetail
    {
        public int ProductId { get; set; }
        public string ArticleNumber { get; set; } = null!;
        public string ProductTitle { get; set; } = null!;
        public string? Description { get; set; }
        public string? Image { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountedPrice { get; set; }    
        public string? Rating { get; set; }
        public int Color { get; set; }  
        public int Size { get; set; }
        public int Quantity { get; set; }

        public IEnumerable<ReviewEntity>? Reviews { get; set; } = new List<ReviewEntity>();

        public static implicit operator ProductProductDetail(ProductDetailEntity entity)
        {
            if (entity != null)
            {
                var productDetail = new ProductProductDetail
                {
                    ProductId = entity.ProductId,
                    ArticleNumber = entity.ArticleNumber,
                    ProductTitle = entity.ProductTitle,
                    Description = entity.ProductDetailDescription,
                    Price = entity.Price,
                    DiscountedPrice = entity.DiscountedPrice,
                    Image = entity.ProductImageUrl,
                    Reviews = entity.ProductModel.Reviews,
                    Color = entity.Color.ColorId, // Handle nullable conversion
                    Size = entity.Size.SizeId,    // Handle nullable conversion
                    Quantity = entity.Quantity
                };
                return productDetail;
            }
            else
            {
                return null;
            }
        }

        public static implicit operator ProductDetailEntity(ProductProductDetail product)
        {
            if (product != null)
            {
                var entity = new ProductDetailEntity
                {
                    ProductId = product.ProductId,
                    ArticleNumber = product.ArticleNumber,
                    ProductTitle = product.ProductTitle,
                    ProductDetailDescription = product.Description,
                    Price = product.Price,
                    ProductImageUrl = product.Image,
                    DiscountedPrice = product.DiscountedPrice,
                    Color = new ProductColorEntity { ColorId = product.Color }, 
                    Size = new ProductSizeEntity { SizeId = product.Size },      
                    Quantity = product.Quantity
                };
                return entity;
            }
            else
            {
                return null;
            }
        }


    }
}

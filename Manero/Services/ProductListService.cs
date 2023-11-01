using Manero.Models.Dtos;
using Manero.Models.Entities;
using Manero.Repository;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Manero.Services
{
    public class ProductListService
    {
        private readonly ProductListRepo _productRepo;
        private readonly ReviewProductListRepo _reviewRepo;

        public ProductListService(ProductListRepo productRepo, ReviewProductListRepo reviewRepo)
        {
            _productRepo = productRepo;
            _reviewRepo = reviewRepo;
        }

        public async Task<IEnumerable<ProductProductList>> GetAllProductsAsync()
        {
            var products = await _productRepo.GetAllAsync();
            

            var productList = new List<ProductProductList>();
            foreach (var product in products)
            {

                productList.Add(new ProductProductList
                {
                    ArticleNumber = product.ArticleNumber,
                    ProductName = product.ProductTitle,
                    Price = product.Price,
                    Image = product.ProductImageUrl,
                    AverageReviewRating = product.ProductModel.Reviews.ToString()




                });  
            }
            return productList;
        }

        public async Task<IEnumerable<ReviewProductList>> GetAllReviewssAsync()
        {
            var products = await _reviewRepo.GetAllAsync();


            var reviewList = new List<ReviewProductList>();
            foreach (var review in reviewList)
            {

                reviewList.Add(new ReviewProductList
                {
                   Rating = review.Rating

                });
            }
            return reviewList;
        }


    }
}

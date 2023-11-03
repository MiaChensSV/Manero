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
        private readonly ShopByTagsRepo _shopByTagsRepo;

        public ProductListService(ProductListRepo productRepo, ReviewProductListRepo reviewRepo, ShopByTagsRepo shopByTagsRepo)
        {
            _productRepo = productRepo;
            _reviewRepo = reviewRepo;
            _shopByTagsRepo = shopByTagsRepo;
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
                  //Rating = product.ProductModel.Reviews




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

        public async Task<IEnumerable<ProductProductList>> GetAllByTagNameAsync(string tagName)
        {
            var products = await _shopByTagsRepo.GetAllAsync(tagName);

            var productList = new List<ProductProductList>();
            foreach (var product in products)
            {
                var tagList = new List<string>();

                foreach (var tag in product.ProductModel.Tags)
                    tagList.Add(tag.Tag.TagName);

                productList.Add(new ProductProductList
                {
                    ArticleNumber = product.ArticleNumber,
                    ProductName = product.ProductTitle,
                   
                    Tags = tagList,
                   
                    Price = product.Price,
                    Image = product.ProductImageUrl
                });
            }
            return productList;

        }

    }





}

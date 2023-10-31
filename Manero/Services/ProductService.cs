using Manero.Models.Dtos;
using Manero.Models.Entities;
using Manero.Repository;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Manero.Services
{
    public class ProductService
    {
        private readonly ProductRepo _productRepo;

        public ProductService(ProductRepo productRepo)
        {
            _productRepo = productRepo;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            var products = await _productRepo.GetAllAsync();

            var productList = new List<Product>();
            foreach (var product in products)
            {

                productList.Add(new Product
                {
                   ArticleNumber = product.ArticleNumber,
                   ProductName = product.ProductTitle,
                   Price = product.Price,
                   Image = product.ProductImageUrl
                });
            }
            return productList;
        }
    }
}

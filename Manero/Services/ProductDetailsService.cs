using Manero.Context;
using Manero.Models.Dtos;

using Manero.Repository;


namespace Manero.Services
{
    public class ProductDetailsService
    {
        private readonly DataContext _context;
        private readonly ProductDetailsRepo _productDetailsRepo;

        public ProductDetailsService(ProductDetailsRepo productDetailsRepo, DataContext context)
        {
            _context = context;
            _productDetailsRepo = productDetailsRepo;
        }

        public async Task<ProductProductDetail> GetProductDetailAsync(ProductProductDetail product)
        {
            var _entity = await _productDetailsRepo.GetAsync(x =>
                x.ArticleNumber == product.ArticleNumber);
            return _entity;
        }
    }
}

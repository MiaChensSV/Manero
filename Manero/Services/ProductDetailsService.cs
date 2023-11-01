using Manero.Context;
using Manero.Models.Entities;
using Manero.Repository;
using System.Linq.Expressions;

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

        public async Task<ProductDetailEntity> GetProductDetailAsync(Expression<Func<ProductDetailEntity, bool>> expression)
        {
            return await _productDetailsRepo.GetAsync(expression);
        }
    }
}

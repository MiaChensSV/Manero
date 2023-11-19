using Manero.Context;
using Manero.Models.Dtos;

using Manero.Repository;


namespace Manero.Services
{
    public class ProductDetailsService
    {
        private readonly DataContext _context;
        private readonly IProductDetailsRepo _productDetailsRepo;

        public ProductDetailsService(IProductDetailsRepo productDetailsRepo, DataContext context)
        {
            _context = context;
            _productDetailsRepo = productDetailsRepo;
        }

        public async Task<ProductProductDetail> GetProductDetailByIdAsync(int id)
        {
            var _entity = await _productDetailsRepo.GetAsync(x => x.ProductId == id);
            if (_entity != null)
            {
                return _entity;
            }
            else
            {
                return null!;
            }
        }
    }
}


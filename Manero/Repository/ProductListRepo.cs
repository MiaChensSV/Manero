using Manero.Context;
using Manero.Models.Dtos;
using Manero.Models.Entities;
using Microsoft.EntityFrameworkCore;


namespace Manero.Repository
{
    public interface IProductListRepo
    {
        Task<IEnumerable<ProductDetailEntity>> GetAllAsync();
        Task<ProductDetailEntity> GetAsync();
    }
    public class ProductListRepo : GeneralRepo<ProductDetailEntity>
    {
        private readonly DataContext _dataContext;
        public ProductListRepo(DataContext dataContext) : base(dataContext)
        {
            _dataContext= dataContext;
        }

        public async Task<IEnumerable<ProductDetailEntity>> GetAllAsync()
        {
            var products = await _dataContext.ProductDetail
                .Include(b => b.ProductModel)
                .ThenInclude(p => p.Reviews)
                .ToListAsync();

            return products;

        }

      

        public async override Task<ProductDetailEntity> GetAsync()
        {
            var product = await _dataContext.ProductDetail
                .Include(p => p.ProductModel)
                .ThenInclude(p => p.Reviews)
                .FirstOrDefaultAsync();

            return product!;
        }

        
    }
}

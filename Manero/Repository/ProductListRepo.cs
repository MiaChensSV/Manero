using Manero.Context;
using Manero.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Linq.Expressions;

namespace Manero.Repository
{
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

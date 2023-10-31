using Manero.Context;
using Manero.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Manero.Repository
{
    public class ProductRepo : GeneralRepo<ProductDetailEntity>
    {
        private readonly DataContext _dataContext;
        public ProductRepo(DataContext dataContext) : base(dataContext)
        {
            _dataContext= dataContext;
        }

        public override async Task<IEnumerable<ProductDetailEntity>> GetAllAsync()
        {
            var products = await _dataContext.ProductDetail
                .Include(p => p.ProductModel)
                .ThenInclude(p => p.Products)
                .ToListAsync();

            return products;

        }

        public override Task<IEnumerable<ProductDetailEntity>> GetAllAsync(Expression<Func<ProductDetailEntity, bool>> expression)
        {
            return base.GetAllAsync(expression);
        }

        public override Task<ProductDetailEntity> GetAsync(Expression<Func<ProductDetailEntity, bool>> expression)
        {
            return base.GetAsync(expression);
        }
    }
}

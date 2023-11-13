using Manero.Context;
using Manero.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Manero.Repository
{
    public class ProductDetailsRepo : GeneralRepo<ProductDetailEntity>
    {
        private readonly DataContext _dataContext;
        public ProductDetailsRepo(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }


        public override async Task<ProductDetailEntity> GetAsync(Expression<Func<ProductDetailEntity, bool>> expression)
        {
            try
            {
                var product = await _dataContext.ProductDetail
                  .Include(b => b.ProductModel)
                  .ThenInclude(p => p.Reviews)
                  .Include(p => p.Size)
                  .Include(p => p.Color)
                  .FirstOrDefaultAsync(expression);

                return product;
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}

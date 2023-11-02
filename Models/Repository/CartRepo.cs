using Manero.Context;
using Manero.Models.Entities;
using Manero.Repository;
using System.Linq.Expressions;

namespace Manero.Models.Repository
{
    public class CartRepo : GeneralRepo<ProductDetailEntity>
    {
        private readonly DataContext _context;

        public CartRepo(DataContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<ProductDetailEntity> GetAsync(Expression<Func<ProductDetailEntity, bool>> expression)
        {
            return await base.GetAsync(expression);
        }

    }
}

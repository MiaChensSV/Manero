using Manero.Context;
using Manero.Models.Entities;
using System.Linq.Expressions;

namespace Manero.Repository
{
    public class ProductDetailsRepo : GeneralRepo<ProductDetailEntity>
    {
        private readonly DataContext _context;

        public ProductDetailsRepo(DataContext context) : base(context) 
        {
            _context = context;
        }

       
    }
}

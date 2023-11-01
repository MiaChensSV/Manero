using Manero.Context;
using Manero.Models.Entities;
using System.Linq.Expressions;

namespace Manero.Repository
{
    public class WishListRepo : GeneralRepo<ProductWishListEntity>
    {
        private readonly DataContext _dataContext;
        public WishListRepo(DataContext context, DataContext dataContext) : base(context)
        {
            _dataContext = dataContext;
        }

     
    }
}

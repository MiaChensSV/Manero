using Manero.Context;
using Manero.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Manero.Repository
{
    public class ReviewProductListRepo : GeneralRepo<ReviewEntity>
    {
        private readonly DataContext _dataContext;
        public ReviewProductListRepo(DataContext context, DataContext dataContext) : base(context)
        {
            _dataContext = dataContext;
        }

      

        public  async Task<IEnumerable<ReviewEntity>> GetAllAsync()
        {
            var reviews = await _dataContext.Reviews.ToListAsync();

            return reviews;

        }

        
    }
}

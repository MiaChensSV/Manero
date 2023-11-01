using Manero.Context;
using Manero.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Manero.Repository
{
    public class AccountWishListRepo : GeneralRepo<AppIdentityUser>
    {
        private readonly DataContext _dataContext;
        public AccountWishListRepo(DataContext context, DataContext dataContext) : base(context)
        {
            _dataContext = dataContext;
        }

        public override Task<AppIdentityUser> AddAsync(AppIdentityUser entity)
        {
            return base.AddAsync(entity);
        }

       


    }
}

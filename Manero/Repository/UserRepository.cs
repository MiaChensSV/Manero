using Manero.Context;
using Manero.Models.Entities;

namespace Manero.Repository
{
    public class UserRepository : GeneralRepo<AppIdentityUser>
    {

        private readonly DataContext _context;
        public UserRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<AppIdentityUser> GetUserAsync(string user)
        {
            var AppUser = await _context.Users.FindAsync(user);

            if (AppUser != null)
            {
                return AppUser;
            }

            return null!;
        }

    }
}

using Manero.Context;
using Manero.Models.Entities;
using Manero.Repository;
using Microsoft.EntityFrameworkCore;


namespace Manero.Models.Repository
{
    public class UserAddressRepository : GeneralRepo<UserAddressEntity>
    {
        private readonly DataContext _context;

        public UserAddressRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserAddressEntity>> GetAllAddressesAsync(string user)
        {
            var useraddresses = await _context.AppUserAddress
                .Include(x => x.Address)
                .Where(x => x.UserId == user)
                .ToListAsync();

            return useraddresses;
        }

        
    }
}

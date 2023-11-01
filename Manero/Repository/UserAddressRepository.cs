using Manero.Context;
using Manero.Models.Entities;
using Manero.Repository;


namespace Manero.Models.Repository
{
    public class UserAddressRepository : GeneralRepo<UserAddressEntity>
    {
        public UserAddressRepository(DataContext context) : base(context)
        {
        }
    }
}

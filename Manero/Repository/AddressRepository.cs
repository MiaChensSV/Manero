using Manero.Context;
using Manero.Models.Entities;
using Manero.Repository;

namespace Manero.Models.Repository
{
    public class AddressRepository : GeneralRepo<AddressEntity>
    {
        public AddressRepository(DataContext context) : base(context)
        {
        }
    }
}

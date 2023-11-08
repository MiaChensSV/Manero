using Manero.Context;
using Manero.Models.Entities;

namespace Manero.Repository
{
    public class CheckOutRepository : GeneralRepo<OrderEntity>
    {
        public CheckOutRepository(DataContext context) : base(context)
        {
        }
    }
}
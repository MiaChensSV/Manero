using Manero.Context;
using Manero.Models.Entities;
using Manero.Repository;

namespace Manero.Models.Repository
{
    public class CreditCardRepository : GeneralRepo<CreditCardsEntity>
    {
        public CreditCardRepository(DataContext context) : base(context)
        {
        }
    }
}

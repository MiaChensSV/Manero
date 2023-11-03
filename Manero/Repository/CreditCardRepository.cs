using Manero.Context;
using Manero.Models.Entities;
using Manero.Repository;
using Microsoft.EntityFrameworkCore;

namespace Manero.Models.Repository
{
    public class CreditCardRepository : GeneralRepo<CreditCardsEntity>
    {

        private readonly DataContext _context;
        public CreditCardRepository(DataContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<CreditCardsEntity>> GetAllCreditCardsAsync(string user)
        {
            var creditCards = await _context.CreditCards
                .Where(x => x.UserId == user)
                .ToListAsync();

            return creditCards;
        }
    }
}

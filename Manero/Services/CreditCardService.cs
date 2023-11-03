using Manero.Models.Entities;
using Manero.Models.Repository;
using Manero.ViewModels;

namespace Manero.Services
{
    public class CreditCardService
    {
        private readonly CreditCardRepository _creditCardRepository;

        public CreditCardService(CreditCardRepository creditCardRepository)
        {
            _creditCardRepository = creditCardRepository;
        }

        public async Task<CreditCardsEntity> GetOrCreateAsync(AddCreditCardViewModel model, string user)
        {

            var entity = await _creditCardRepository.GetAsync(x =>
                x.CardNumber == model.CardNumber
                );

            entity ??= await _creditCardRepository.AddAsync(new CreditCardsEntity
                {
                    UserId = user,
                    CardNumber = model.CardNumber,
                    CVV = model.CVV,
                    ExpireDate = model.ExpireDate,
                    CreditCardName = model.CreditCardName,
                });

            return entity!;

        }
    }
}

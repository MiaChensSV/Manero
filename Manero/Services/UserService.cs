using Manero.Models.Entities;
using Manero.Models.Repository;
using Manero.Repository;

namespace Manero.Services;

    public class UserService
    {
        private readonly UserAddressRepository _userAddressRepository;
        private readonly CreditCardRepository _creditCardRepository;
	public UserService(UserAddressRepository userAddressRepository, CreditCardRepository creditCardRepository)
	{
		_userAddressRepository = userAddressRepository;
		_creditCardRepository = creditCardRepository;
	}



	public async Task<CreditCardsEntity> GetDefaultCardAsync(string userId)
        {
            IEnumerable<CreditCardsEntity> _creditCards = await _creditCardRepository.GetAllCreditCardsAsync(userId);
            List<CreditCardsEntity> _creditcardsList = _creditCards.ToList();
			if (_creditcardsList.Count > 0)
			{
				return _creditcardsList[0];

			}
			else
				return null!;
	}

	public async Task<UserAddressEntity> GetDefaultAddressAsync(string userId)
	{
		IEnumerable<UserAddressEntity> _addresses = await _userAddressRepository.GetAllAddressesAsync(userId);
		List<UserAddressEntity> _addressesList = _addresses.ToList();
		if (_addressesList.Count > 0)
		{
			return _addressesList[0];
		}
		else
			return null!;
	}
}

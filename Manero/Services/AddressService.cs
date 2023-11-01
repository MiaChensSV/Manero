using Manero.Models.Entities;
using Manero.Models.Repository;
using Manero.ViewModels;

namespace Manero.Services
{
    public class AddressService
    {
        private readonly AddressRepository _addressRepository;
        private readonly UserAddressRepository _userAddressRepository;

        public AddressService(AddressRepository addressRepo, UserAddressRepository userAddressRepository)
        {
            _addressRepository = addressRepo;
            _userAddressRepository = userAddressRepository;
        }


        // Checks if address exists, if not creates the address
        public async Task<AddressEntity> GetOrCreateAsync(AddressViewModel address)
        {
            var entity = await _addressRepository.GetAsync(x =>
                x.StreetName == address.StreetName &&
                x.City == address.City &&
                x.PostalCode == address.PostalCode &&
                x.Country == address.Country
                );

            entity ??= await _addressRepository.AddAsync(address);

            return entity!;

        }

        // Creates a relation between the user and the address table
        public async Task AddAddressAsync(string user, AddressEntity addressEntity)
        {
            await _userAddressRepository.AddAsync(new UserAddressEntity
            {
                UserId = user,
                AddressId = addressEntity.AddressId
            });
        }
    }
}

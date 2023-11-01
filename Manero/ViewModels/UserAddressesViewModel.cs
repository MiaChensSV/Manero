using Manero.Models.Entities;

namespace Manero.ViewModels;

public class UserAddressesViewModel
{
   
    public IEnumerable<UserAddressEntity> UserAddresses { get; set; } = new List<UserAddressEntity>();

}

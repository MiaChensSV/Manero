using Manero.Models.Entities;
using Manero.Repository;
using Manero.ViewModels;

namespace Manero.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<AppIdentityUser> UpdateUserInfo(EditUserViewModel viewModel, string user)
        {
            var getUser = await _userRepository.GetUserAsync(user);

            if (getUser != null)
            {
                await _userRepository.UpdateAsync(AppIdentityUser user) {

                }
            }

            return null!;
        }
    }
}

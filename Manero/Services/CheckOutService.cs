using Manero.Models.Entities;
using Manero.Repository;
using Manero.ViewModels;

namespace Manero.Services
{
    public class CheckOutService
    {
        private readonly CheckOutRepository _checkOutRepository;

        public CheckOutService(CheckOutRepository checkOutRepository)
        {
            _checkOutRepository = checkOutRepository;
        }
        public async Task<OrderEntity> RegisterAsync(CheckOutViewModel viewmodel)
        {
            var order = await _checkOutRepository.AddAsync(viewmodel);
            return order;


        }

    }
}

using Manero.Context;
using Manero.Models.Entities;

namespace Manero.Repository
{
	public class CheckOutRepository : GeneralRepo<OrderEntity>
	{

		private readonly DataContext _dataContext;

		public CheckOutRepository(DataContext context) : base(context)
		{
		}

		public CheckOutRepository(DataContext context, DataContext dataContext) : base(context)
		{
			_dataContext = dataContext;
		}

		public override Task<OrderEntity> AddAsync(OrderEntity entity)
		{
			return base.AddAsync(entity);
		}

		/*
            public async override Task<OrderEntity> AddAsync(CheckoutViewModel viewModel) {

            } 
            */
		/*
        public async Task<OrderEntity> GetCheckoutAsync(int orderId)
        {
            return _dataContext.(x => x.OrderId == orderId);
        */
	}
}
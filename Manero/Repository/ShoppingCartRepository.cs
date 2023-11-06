using System.Linq.Expressions;
using Manero.Context;
using Manero.Models.Entities;
using Microsoft.EntityFrameworkCore;
using MySqlX.XDevAPI.Relational;

namespace Manero.Repository
{
	public class ShoppingCartRepository : GeneralRepo<OrderDetailEntity>
	{
		private readonly DataContext _context;

		public ShoppingCartRepository(DataContext context) : base(context)
		{
			_context = context;
		}

		public async Task<IEnumerable<OrderDetailEntity>> GetCartByUser(string userId)
		{
			int _orderId = GetOrderIdByUser(userId).Result;
			var _orderDetailList = await _context.OrderDetail
				.Where(row => row.OrderId == _orderId)
				.ToListAsync();
			return _orderDetailList;
		}

		public async Task UpdateCartByUser(OrderDetailEntity cartItem)
		{
			_context.OrderDetail.Update(cartItem);
			await _context.SaveChangesAsync();
		}
		public async Task DeleteCartItemByUser(OrderDetailEntity cartItem)
		{
			_context.OrderDetail.Remove(cartItem);
			await _context.SaveChangesAsync();
		}

		private async Task<int> GetOrderIdByUser(string userId)
		{
			var _orderDetails = await _context.OrderDetails
				.Where(row => row.UserId == userId)
				.Where(row => row.StatusId == 1)
				.OrderBy(row => row.Modified_Date)
				.LastOrDefaultAsync();
			if (_orderDetails != null)
				return _orderDetails.OrderId;
			else
				return -1;
		}
	}
}
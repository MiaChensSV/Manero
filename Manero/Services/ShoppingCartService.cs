using Manero.Models.Entities;
using Manero.Repository;

namespace Manero.Services;

public class ShoppingCartService
{
	private readonly ShoppingCartRepository _cartRepo;

	public ShoppingCartService(ShoppingCartRepository cartRepo)
	{
		_cartRepo = cartRepo;
	}

	public async Task CreateCartItemByUserAsync(string userId, string artNum)
	{
		await _cartRepo.CreateCartItemByUser(userId, artNum);
	}

	public async Task<IEnumerable<OrderDetailEntity>> GetCartByUserAsync(string userId)
	{
		return await _cartRepo.GetCartByUser(userId);
	}

	public async Task UpdateCartByUserAsnyc(OrderDetailEntity newItem)
	{
		await _cartRepo.UpdateCartByUser(newItem);
	}

	public async Task DeleteCartItemByUserAsync(OrderDetailEntity item)
	{
		await _cartRepo.DeleteCartItemByUser(item);
	}
}
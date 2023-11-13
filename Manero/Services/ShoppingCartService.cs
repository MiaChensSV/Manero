using Manero.Models.Entities;
using Manero.Repository;

namespace Manero.Services;

public class ShoppingCartService
{
	private readonly ShoppingCartRepository _cartRepo;
	private readonly CheckOutRepository _checkoutRepo;

	public ShoppingCartService(ShoppingCartRepository cartRepo, CheckOutRepository checkOutRepository)
	{
		_cartRepo = cartRepo;
		_checkoutRepo = checkOutRepository;
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
	public async Task SaveToDb(OrderEntity entity)
	{
		await _checkoutRepo.AddAsync(entity);
	}
}
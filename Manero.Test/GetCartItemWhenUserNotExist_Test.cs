using System;
using System.Collections.Generic;
using System.Linq;
using Manero.Context;
using Manero.Models.Entities;
using Manero.Repository;
using Microsoft.EntityFrameworkCore;

namespace Manero.Test.Mia;

public class GetCartItemWhenUserNotExist_Test
{
	private readonly DataContext _context;
	private readonly ShoppingCartRepository _shopingCartRepository;

	public GetCartItemWhenUserNotExist_Test()
	{
		var _options = new DbContextOptionsBuilder<DataContext>()
			.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
			.Options;
		_context = new DataContext(_options);
		_shopingCartRepository = new ShoppingCartRepository(_context);
	}


	[Fact]
	public async Task GetCartItemWhenUserNotExist()
	{
		var _user = _context.OrderDetails.Where(row => row.UserId == "do not exist");
		_context.RemoveRange(_user);
		_context.SaveChanges();

		string _userId = "do not exist";
		IEnumerable<OrderDetailEntity> _orderedItemList = await _shopingCartRepository.GetCartByUser(_userId);
		Assert.Empty(_orderedItemList);
	}
}

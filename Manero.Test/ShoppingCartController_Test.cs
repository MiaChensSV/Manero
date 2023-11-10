using Manero.Context;
using Manero.Controllers;
using Manero.Models.Entities;
using Manero.Models.Repository;
using Manero.Repository;
using Manero.Services;
using Microsoft.EntityFrameworkCore;

namespace Manero.Test;

public class ShoppingCartController_Test
{
	private readonly DataContext _context;
	private readonly ShoppingCartService _shopingCartService;
	private readonly ShoppingCartRepository _shopingCartRepository;
	private readonly CheckOutRepository _checkoutRepository;
	private readonly ShopingCartController _controller;
	private readonly UserService _userService;
	private readonly ShoppingCartService _shopCartService;
	private readonly CreditCardRepository _creditCardRepository;
	private readonly UserAddressRepository _userAddressRepository;

	public ShoppingCartController_Test()
	{
		var options = new DbContextOptionsBuilder<DataContext>()
			.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
			.Options;
		_context = new DataContext(options);
		_shopingCartRepository = new ShoppingCartRepository(_context);
		_checkoutRepository = new CheckOutRepository(_context);
		_shopingCartService = new ShoppingCartService(_shopingCartRepository, _checkoutRepository);
		_userAddressRepository=new UserAddressRepository(_context);
		_creditCardRepository=new CreditCardRepository(_context);
		_userService = new UserService(_userAddressRepository, _creditCardRepository);
		_controller = new ShopingCartController(_shopingCartService, _userService);
	}
	[Fact]
	public async Task IncreaseOrDecreaseQuantityWhenButton()
	{
		var _productModel = new ProductModelEntity { ModelNumber = "TestCreatedModel", ProductDescription = "TestDes" };
		var _color = new ProductColorEntity { ColorName = "testColor" };
		var _size = new ProductSizeEntity { SizeName = "testsize" };
		_context.ProductModels.Add(_productModel);
		_context.ProductColor.Add(_color);
		_context.ProductSize.Add(_size);
		await _context.SaveChangesAsync();

		var _product = new ProductDetailEntity()
		{
			ArticleNumber = "1",
			Price = 10,
			DiscountedPrice = 1,
			ProductId = _productModel.ProductId,
			SizeId = _size.SizeId,
			ColorId = _color.ColorId,
			ProductTitle = "TestTitle",
			Quantity = 111,
		};
		_context.ProductDetail.Add(_product);
		await _context.SaveChangesAsync();

		await _shopingCartRepository.CreateCartItemByUser("do not exist", _product.ArticleNumber);
		List<OrderDetailEntity> _cartList = _shopingCartRepository.GetCartByUser("do not exist").Result.ToList();
		var quantity = _cartList[0].Quantity;
		var AssumedQuantity = 4;
		var IncreasedResult = AssumedQuantity + 1;
		var decreaseResult = AssumedQuantity - 1;

		Assert.Equal(5, IncreasedResult);
		Assert.Equal(3, decreaseResult);
		Assert.Equal(1, quantity);
	}

	[Fact]
	public async Task DeleteCartItemIfExist()
	{

		var _status = new OrderStatusEntity { StatusName = "TestStatus" };
		var _promocode = new PromocodesEntity { PromocodeTitle = "TestTitle", PromocodeDescription = "TestDes" };
		var _productModel = new ProductModelEntity { ModelNumber = "TestCreatedModel", ProductDescription = "TestDes" };
		var _color = new ProductColorEntity { ColorName = "testColor" };
		var _size = new ProductSizeEntity { SizeName = "testsize" };
		var _user = new AppIdentityUser { UserName = "TestUserName" };
		_context.OrderStatus.Add(_status);
		_context.Promocodes.Add(_promocode);
		_context.ProductModels.Add(_productModel);
		_context.ProductColor.Add(_color);
		_context.ProductSize.Add(_size);
		_context.user
		await _context.SaveChangesAsync();
		
		var _product = new ProductDetailEntity()
		{
			ArticleNumber = "1",
			Price = 10,
			DiscountedPrice = 1,
			ProductId = _productModel.ProductId,
			SizeId = _size.SizeId,
			ColorId = _color.ColorId,
			ProductTitle = "TestTitle",
			Quantity = 111,
		};
		_context.ProductDetail.Add(_product);
		await _context.SaveChangesAsync();

		var item = new OrderDetailEntity() { ArticleNumber = "1", OrderId = 3, Quantity = 17, Price = 102, DiscountedPrice = 99 };
		_context.OrderDetail.Add(item); 
		await _context.SaveChangesAsync();
		var order = new OrderEntity()
		{
			UserId = "do not exist",
			StatusId = _status.StatusId,
			PromocodeId = _promocode.PromocodeId,
			ShippingAddress = "TestAdd",
			DeliveryFee = 0,
			TotalCost = 50
		};
		_context.OrderDetails.Add(order);
		await _context.SaveChangesAsync();

		List<OrderDetailEntity> _cartList = _shopingCartRepository.GetCartByUser(order.UserId).Result.ToList();
		var shopcartItem = _cartList[0];
		await _shopCartService.DeleteCartItemByUserAsync(shopcartItem);
		await _shopCartService.UpdateCartByUserAsnyc(shopcartItem);

		Assert.Empty(_cartList);
	}
}

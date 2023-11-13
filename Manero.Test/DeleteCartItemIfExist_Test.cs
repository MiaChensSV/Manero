using Manero.Context;
using Manero.Models.Entities;
using Manero.Repository;
using Manero.Services;
using Microsoft.EntityFrameworkCore;

namespace Manero.Test.Mia;

public class DeleteCartItemIfExist_Test
{
	private readonly DataContext _context;
	private readonly ShoppingCartService _shopingCartService;
	private readonly ShoppingCartRepository _shopingCartRepository;
	private readonly CheckOutRepository _checkoutRepository;

	public DeleteCartItemIfExist_Test()
	{
		var _options = new DbContextOptionsBuilder<DataContext>()
			.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
			.Options;
		_context = new DataContext(_options);
		_shopingCartRepository = new ShoppingCartRepository(_context);
		_checkoutRepository = new CheckOutRepository(_context);
		_shopingCartService = new ShoppingCartService(_shopingCartRepository, _checkoutRepository);
	}


	[Fact]
	public async Task DeleteCartItemIfExist()
	{

		var _status = new OrderStatusEntity { StatusName = "TestStatus" };
		var _promocode = new PromocodesEntity { PromocodeTitle = "TestTitle", PromocodeDescription = "TestDes" };
		var _productModel = new ProductModelEntity { ModelNumber = "TestCreatedModel", ProductDescription = "TestDes" };
		var _color = new ProductColorEntity { ColorName = "testColor" };
		var _size = new ProductSizeEntity { SizeName = "testsize" };
		var _user = new AppIdentityUser { UserName = "TestUserName", FirstName = "TestFirstName", LastName = "TestLastName" };
		_context.OrderStatus.Add(_status);
		_context.Promocodes.Add(_promocode);
		_context.ProductModels.Add(_productModel);
		_context.ProductColor.Add(_color);
		_context.ProductSize.Add(_size);
		_context.Users.Add(_user);
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

		var _order = new OrderEntity()
		{
			UserId = _user.Id,
			StatusId = _status.StatusId,
			PromocodeId = _promocode.PromocodeId,
			ShippingAddress = "TestAdd",
			DeliveryFee = 0,
			TotalCost = 50,
		};
		_context.OrderDetails.Add(_order);

		await _context.SaveChangesAsync();
		var _item = new OrderDetailEntity() { ArticleNumber = "1", OrderId = _order.OrderId, Quantity = 17, Price = 102, DiscountedPrice = 99 };

		_context.OrderDetail.Add(_item);
		await _context.SaveChangesAsync();

		List<OrderDetailEntity> _cartList = _shopingCartRepository.GetCartByUser(_user.Id).Result.ToList();

		var _shopcartItem = _cartList[0];
		await _shopingCartService.DeleteCartItemByUserAsync(_shopcartItem);

		List<OrderDetailEntity> _deletedCartList = _shopingCartRepository.GetCartByUser(_user.Id).Result.ToList();

		Assert.Empty(_deletedCartList);
	}
}

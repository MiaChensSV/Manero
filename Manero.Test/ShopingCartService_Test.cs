using System.Drawing;
using Manero.Context;
using Manero.Models.Entities;
using Manero.Repository;
using Manero.Services;
using Microsoft.EntityFrameworkCore;
using MySqlX.XDevAPI.Relational;

namespace Manero.Test;

public class ShopingCartService_Test
{
    private readonly DataContext _context;
    private readonly ShoppingCartService _shopingCartService;
    private readonly ShoppingCartRepository _shopingCartRepository;
    private readonly CheckOutRepository _checkoutRepository;

    public ShopingCartService_Test()
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
    public async Task GetCartItemWhenUserNotExist()
    {
        var _user = _context.OrderDetails.Where(row => row.UserId == "do not exist");
        _context.RemoveRange(_user);
        _context.SaveChanges();

        string _userId = "do not exist";
        IEnumerable<OrderDetailEntity> _orderedItemList = await _shopingCartRepository.GetCartByUser(_userId);
        Assert.Empty(_orderedItemList);
    }



    [Fact]
    public async Task SaveToDbWhenCreatedCartItembyUser()
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

        Assert.Single(_cartList);
        Assert.Equal(_size.SizeId, _cartList[0].Product.SizeId);
    }
}

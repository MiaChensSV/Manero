using Manero.Models.Entities;
using Manero.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Manero.ViewModels;

namespace Manero.Controllers;

public class ShopingCartController : Controller
{
	private readonly ShoppingCartService _cartService;
	private readonly UserService _userService;

	public ShopingCartController(ShoppingCartService cartService, UserService userService)
	{
		_cartService = cartService;
		_userService = userService;
	}

	public IActionResult Index()
	{
		string _userId = GetUserId();
		List<OrderDetailEntity> _cartList = _cartService.GetCartByUserAsync(_userId).Result.ToList<OrderDetailEntity>();
		decimal _subtotal = 0;
		decimal _discount = 0;

		for(int i=0;i<_cartList.Count;i++)
		{
			_subtotal += _cartList[i].Price * _cartList[i].Quantity;
		}
		CartViewModel _cartViewModel = new ()
		{ 
			OrderDetails=_cartList,
			Subtotal=_subtotal,
			Discount=_discount,
			Total=_subtotal+_discount
		};
		return View(_cartViewModel);
	}

	public async Task<IActionResult> AddAsync(string articleNumber)
	{
		string _userId = GetUserId();
		if(_userId != null)
		{
			var _cartList = _cartService.GetCartByUserAsync(_userId).Result.ToList<OrderDetailEntity>();
			var _item = _cartList.Find(el => el.ArticleNumber == articleNumber);
			if (_item == null)
			{
				await _cartService.CreateCartItemByUserAsync(_userId, articleNumber);
			}
			else
			{
				_item.Quantity++;
				await _cartService.UpdateCartByUserAsnyc(_item);
			}
			return RedirectToAction("Index");
		}
		else { return RedirectToAction("Denied"); }
		
	}

	public async Task<IActionResult> DeleteAsync(string articleNumber)
	{
		string _userId = GetUserId();
		var _cartList = _cartService.GetCartByUserAsync(_userId).Result.ToList<OrderDetailEntity>();
		var _item = _cartList.Find(el => el.ArticleNumber == articleNumber);
		if (_item != null)
		{
			
				await _cartService.DeleteCartItemByUserAsync(_item);
			
				await _cartService.UpdateCartByUserAsnyc(_item);
			
		}
		return RedirectToAction("Index");
	}

	[Route("shopingcart/increase/{articleNumber}")]
	public async Task<IActionResult> IncreaseAsync(string articleNumber)
	{
        string _userId = GetUserId();
        var _cartList = _cartService.GetCartByUserAsync(_userId).Result.ToList<OrderDetailEntity>();
		var _item = _cartList.Find(el => el.ArticleNumber == articleNumber);
		if (_item != null)
		{
			_item.Quantity++;
			await _cartService.UpdateCartByUserAsnyc(_item);
		}
		return RedirectToAction("Index");
	}
	[Route("shopingcart/decrease/{articleNumber}")]
	public async Task<IActionResult> DecreaseAsync(string articleNumber)
	{
        string _userId = GetUserId();
        var _cartList = _cartService.GetCartByUserAsync(_userId).Result.ToList<OrderDetailEntity>();
		var _item = _cartList.Find(el => el.ArticleNumber == articleNumber);
		if (_item != null)
		{
			_item.Quantity--;
			if (_item.Quantity <= 0)
			{
				await _cartService.DeleteCartItemByUserAsync(_item);
			}
			else
			{
				await _cartService.UpdateCartByUserAsnyc(_item);
			}
		}
		return RedirectToAction("Index");
	}
	
	private string GetUserId()
	{
		string? _userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
		if (_userId == null)
			return null!;
		else
			return _userId;
    }

	public async Task<IActionResult> CheckOut()
	{
		string _userId = GetUserId();
		List<OrderDetailEntity> _cartList = _cartService.GetCartByUserAsync(_userId).Result.ToList<OrderDetailEntity>();
		decimal _subtotal = 0;
		decimal _discount = 0;
		
		for (int i = 0; i < _cartList.Count; i++)
		{
			_subtotal  += _cartList[i].Price * _cartList[i].Quantity;
		}

		var _creditcard = await _userService.GetDefaultCardAsync(_userId);
		var _address = await _userService.GetDefaultAddressAsync(_userId);
		if (_creditcard != null) 
		{
			CheckOutViewModel _checkoutViewModel = new()
			{
				UserId = _userId,
				OrderDetails = _cartList,
				Subtotal = _subtotal,
				Discount = _discount,
				Total = _subtotal + _discount,
				PaymentMethod = _creditcard.CardNumber,
				ShippingAddress = _address.Address.StreetName + _address.Address.City + _address.Address.PostalCode + _address.Address.Country,
				DeliveryFee = 0,
			};
			await _cartService.SaveToDb(_checkoutViewModel);
			return View(_checkoutViewModel);
		}
		else
		{
			CheckOutViewModel _checkoutViewModel = new ()
			{
                UserId = _userId,
                DeliveryFee = 0,
                OrderDetails = _cartList,
				Subtotal = _subtotal,
				Discount = _discount,
				Total = _subtotal + _discount,
				PaymentMethod = "",
				ShippingAddress = _address.Address.StreetName + " " + _address.Address.City + " " + _address.Address.PostalCode + " " + _address.Address.Country,
			};
            await _cartService.SaveToDb(_checkoutViewModel);
            return View(_checkoutViewModel);
		}				
	}

	[Route("shopingcart/AccessDenied")]
	public IActionResult Denied()
	{
		return View();
	}
}
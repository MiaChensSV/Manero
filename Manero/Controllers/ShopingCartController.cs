using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using Manero.Models.Entities;
using Manero.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Org.BouncyCastle.Bcpg;
using System.Security.Claims;
using Manero.ViewModels;
using ZstdSharp.Unsafe;

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
		string userId = GetUserId();
		List<OrderDetailEntity> _cartList = _cartService.GetCartByUserAsync(userId).Result.ToList<OrderDetailEntity>();
		decimal _subtotal = 0;
		decimal _discount = 0;

		for(int i=0;i<_cartList.Count;i++)
		{
			_subtotal= _subtotal+_cartList[i].Price * _cartList[i].Quantity;
		}
		CartViewModel cartViewModel = new ()
		{ 
			OrderDetails=_cartList,
			Subtotal=_subtotal,
			Discount=_discount,
			Total=_subtotal+_discount
		};
		return View(cartViewModel);
	}

	public async Task<IActionResult> AddAsync(string articleNumber)
	{
		string userId = GetUserId();
		if(userId !=null)
		{
			var _cartList = _cartService.GetCartByUserAsync(userId).Result.ToList<OrderDetailEntity>();
			var item = _cartList.Find(el => el.ArticleNumber == articleNumber);
			if (item == null)
			{
				await _cartService.CreateCartItemByUserAsync(userId, articleNumber);
			}
			else
			{
				item.Quantity++;
				await _cartService.UpdateCartByUserAsnyc(item);
			}
			return RedirectToAction("Index");
		}
		else { return RedirectToAction("Denied"); }
		
	}

	public async Task<IActionResult> DeleteAsync(string articleNumber)
	{
		string userId = GetUserId();
		var _cartList = _cartService.GetCartByUserAsync(userId).Result.ToList<OrderDetailEntity>();
		var item = _cartList.Find(el => el.ArticleNumber == articleNumber);
		if (item != null)
		{
			
				await _cartService.DeleteCartItemByUserAsync(item);
			
				await _cartService.UpdateCartByUserAsnyc(item);
			
		}
		return RedirectToAction("Index");
	}

	[Route("shopingcart/increase/{articleNumber}")]
	public async Task<IActionResult> IncreaseAsync(string articleNumber)
	{
        string userId = GetUserId();
        var _cartList = _cartService.GetCartByUserAsync(userId).Result.ToList<OrderDetailEntity>();
		var item = _cartList.Find(el => el.ArticleNumber == articleNumber);
		if (item != null)
		{
			item.Quantity++;
			await _cartService.UpdateCartByUserAsnyc(item);
		}
		return RedirectToAction("Index");
	}
	[Route("shopingcart/decrease/{articleNumber}")]
	public async Task<IActionResult> DecreaseAsync(string articleNumber)
	{
        string userId = GetUserId();
        var _cartList = _cartService.GetCartByUserAsync(userId).Result.ToList<OrderDetailEntity>();
		var item = _cartList.Find(el => el.ArticleNumber == articleNumber);
		if (item != null)
		{
			item.Quantity--;
			if (item.Quantity <= 0)
			{
				await _cartService.DeleteCartItemByUserAsync(item);
			}
			else
			{
				await _cartService.UpdateCartByUserAsnyc(item);
			}
		}
		return RedirectToAction("Index");
	}
	
	private string GetUserId()
	{
		string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
		if (userId == null)
			return null!;
		else
			return userId;
    }

	public async Task<IActionResult> CheckOut()
	{
		string userId = GetUserId();
		List<OrderDetailEntity> _cartList = _cartService.GetCartByUserAsync(userId).Result.ToList<OrderDetailEntity>();
		decimal _subtotal = 0;
		decimal _discount = 0;
		
		for (int i = 0; i < _cartList.Count; i++)
		{
			_subtotal = _subtotal + _cartList[i].Price * _cartList[i].Quantity;
		}

		var _creditcard = await _userService.GetDefaultCardAsync(userId);
		var _address = await _userService.GetDefaultAddressAsync(userId);
		if (_creditcard != null) 
		{
			CheckOutViewModel checkoutViewModel = new()
			{
				UserId = userId,
				OrderDetails = _cartList,
				Subtotal = _subtotal,
				Discount = _discount,
				Total = _subtotal + _discount,
				PaymentMethod = _creditcard.CardNumber,
				ShippingAddress = _address.Address.StreetName + _address.Address.City + _address.Address.PostalCode + _address.Address.Country,
				DeliveryFee = 0,
			};
			await _cartService.SaveToDb(checkoutViewModel);
			return View(checkoutViewModel);
		}
		else
		{
			CheckOutViewModel checkoutViewModel = new ()
			{
                UserId = userId,
                DeliveryFee = 0,
                OrderDetails = _cartList,
				Subtotal = _subtotal,
				Discount = _discount,
				Total = _subtotal + _discount,
				PaymentMethod = "",
				ShippingAddress = _address.Address.StreetName + " " + _address.Address.City + " " + _address.Address.PostalCode + " " + _address.Address.Country,
			};
            await _cartService.SaveToDb(checkoutViewModel);
            return View(checkoutViewModel);
		}				
	}

	[Route("shopingcart/AccessDenied")]
	public IActionResult Denied()
	{
		return View();
	}
}
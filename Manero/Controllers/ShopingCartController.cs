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

	public ShopingCartController(ShoppingCartService cartService)
	{
		_cartService = cartService;
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
		CartViewModel cartViewModel = new CartViewModel() 
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
		var _cartList = _cartService.GetCartByUserAsync(userId).Result.ToList<OrderDetailEntity>();
		var item = _cartList.Find(el => el.ArticleNumber == articleNumber);
		if(item == null)
		{
			await _cartService.CreateCartItemByUserAsync(userId, articleNumber);
		} else
		{
			item.Quantity++;
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
			return "";
		else
			return userId;
    }

	public IActionResult CheckOut()
	{
		return View();
	}
}
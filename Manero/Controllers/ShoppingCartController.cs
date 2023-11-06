using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using Manero.Models.Entities;
using Manero.Services;
using Microsoft.AspNetCore.Mvc;

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
		List<OrderDetailEntity> _cartList = _cartService.GetCartByUserAsync("47b924bd-957e-409a-9aa8-819aa02c2b4b").Result.ToList<OrderDetailEntity>();
		return View(_cartList);
	}

	[Route("shopingcart/increase/{articleNumber}")]
	public async Task<IActionResult> IncreaseAsync(string articleNumber)
	{
		var _cartList = _cartService.GetCartByUserAsync("47b924bd-957e-409a-9aa8-819aa02c2b4b").Result.ToList<OrderDetailEntity>();
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
		var _cartList = _cartService.GetCartByUserAsync("47b924bd-957e-409a-9aa8-819aa02c2b4b").Result.ToList<OrderDetailEntity>();
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
}
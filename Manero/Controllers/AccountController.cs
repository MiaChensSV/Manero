using Manero.Models.Entities;
using Manero.Repository;
using Manero.Services;
using Manero.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Manero.Controllers;

public class AccountController : Controller
{

    private readonly ProductListService _productListService;
   


    public AccountController( ProductListService productListService)
    {
        _productListService = productListService;
    }

    public IActionResult Index()
    {
        return View();
    }


	public IActionResult MyAccount()
	{

		return View();
	}

    public IActionResult Edit()
    {

        return View();
    }
    public IActionResult Orders()
    {

        return View();
    }

    public async Task <IActionResult> Wishlist(string articleNumber)
    {

            
            var product = await _productListService.GetProductByArticleNumberAsync(articleNumber);

       
        return View(product);

       
    }

    public IActionResult AddToWishlist()
    {
        
    
        return View();
    }

    public IActionResult SignOutUser()
    {

        return View();
    }

    public IActionResult PromoCode()
    {

        return View();
    }

}

   



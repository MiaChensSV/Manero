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

    public IActionResult Wishlist()
    {

        return View();

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

   



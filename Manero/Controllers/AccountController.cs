using Manero.Models.Entities;
using Manero.Services;
using Manero.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Manero.Controllers;

public class AccountController : Controller
{

    private readonly AddressService _addressService;
    private readonly UserManager<AppIdentityUser> _userManger;


    public AccountController(AddressService addressService, UserManager<AppIdentityUser> userManger)
    {
        _addressService = addressService;
        _userManger = userManger;
    }

    public IActionResult Index()
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


    public IActionResult SignOutUser()
    {

        return View();
    }

    public IActionResult PromoCode()
    {

        return View();
    }

    public IActionResult MyAddress()
    {
        return View();
    }


    public IActionResult AddAddress()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> AddAddress(AddressViewModel addressView)
    {
        if (ModelState.IsValid)
        {

            var getAddress = await _addressService.GetOrCreateAsync(addressView);
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            await _addressService.AddAddressAsync(userId, getAddress);
        }

        return View();
    }

}





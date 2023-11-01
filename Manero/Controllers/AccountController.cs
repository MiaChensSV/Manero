using Manero.Models.Entities;
using Manero.Models.Repository;
using Manero.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace Manero.Controllers;

public class AccountController : Controller
{

    private readonly AddressRepository _addressRepository;
    private readonly AppIdentityUser _user;

    public AccountController(AddressRepository addressRepository, AppIdentityUser user)
    {
        _addressRepository = addressRepository;
        _user = user;
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
    public async Task<IActionResult>AddAddress(AddressViewModel addressView, AppIdentityUser user)
    {
        if (ModelState.IsValid)
        {

            

            // Check if address already exist, else add it to Database
            // Create relation beteween user and addresses

            await _addressRepository.AddAsync(addressView);
        }

        return View();
    }

}

   



using Manero.Models.Entities;
using Manero.Models.Repository;
using Manero.Repository;
using Manero.Services;
using Manero.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using System.Security.Claims;

namespace Manero.Controllers;

public class AccountController : Controller
{

    private readonly AddressService _addressService;
    private readonly UserManager<AppIdentityUser> _userManger;
    private readonly UserAddressRepository _userAddressRepository;
    private readonly CreditCardService _creditCardService;


    public AccountController(AddressService addressService, UserManager<AppIdentityUser> userManger, UserAddressRepository userAddressRepository, CreditCardService creditCardService)
    {
        _addressService = addressService;
        _userManger = userManger;
        _userAddressRepository = userAddressRepository;
        _creditCardService = creditCardService;
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




    public IActionResult PaymentMethods()
    {
        return View();
    }

    public IActionResult AddCreditCard()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> AddCreditCard(AddCreditCardViewModel model)
    {

        if (ModelState.IsValid)
        {
            try
            {
                
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (userId != null)
                {
                    await _creditCardService.GetOrCreateAsync(model, userId);
                    return RedirectToAction("PaymentMethods", "Account");
                }
            }
            catch
            {
                ModelState.AddModelError("", "Could not save you creditcard to profile.");
            }
        }

        return View();
    }



    // Gets all user addresses by userID.

    public async Task<IActionResult> MyAddress()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);


        if (userId != null)
        {
            var viewModel = new UserAddressesViewModel
            {
                UserAddresses = await _userAddressRepository.GetAllAddressesAsync(userId)
            };

            return View(viewModel);
        }

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
            try
            {
                var getAddress = await _addressService.GetOrCreateAsync(addressView);
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                if (userId != null)
                {
                    await _addressService.AddAddressAsync(userId, getAddress, addressView.LocationName!);
                    return RedirectToAction("MyAddress", "Account");
                }

            }catch
            {
                ModelState.AddModelError("","This address is already saved on your profile.");
            }


        }

        return View();
    }

}





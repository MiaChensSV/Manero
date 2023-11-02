using Manero.Models.Entities;
using Manero.Models.Repository;
using Manero.Repository;
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
    private readonly UserAddressRepository _userAddressRepository;
    private readonly CreditCardService _creditCardService;
    private readonly CreditCardRepository _creditCardsRepository;
    private readonly UserRepository _userRepository;

    public AccountController(AddressService addressService, UserManager<AppIdentityUser> userManger, UserAddressRepository userAddressRepository, CreditCardService creditCardService, CreditCardRepository creditCardsRepository, UserRepository userRepository)
    {
        _addressService = addressService;
        _userManger = userManger;
        _userAddressRepository = userAddressRepository;
        _creditCardService = creditCardService;
        _creditCardsRepository = creditCardsRepository;
        _userRepository = userRepository;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Edit()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Edit(EditUserViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var newUser = await _userManger.FindByIdAsync(userId);


        }

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




    public async Task<IActionResult> PaymentMethods()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);


        if (userId != null)
        {
            var viewModel = new CreditCardViewModel
            {
                CreditCards = await _creditCardsRepository.GetAllCreditCardsAsync(userId)
            };

            return View(viewModel);
        }
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

            }
            catch
            {
                ModelState.AddModelError("", "This address is already saved on your profile.");
            }


        }

        return View();
    }

}





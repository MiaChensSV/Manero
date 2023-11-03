using Manero.Models.Entities;
using Manero.Models.Repository;
using Manero.Repository;
using Manero.Services;
using Manero.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.ConstrainedExecution;
using System.Security.Claims;

namespace Manero.Controllers;

public class AccountController : Controller
{

    private readonly AddressService _addressService;
    private readonly UserManager<AppIdentityUser> _userManager;
    private readonly UserAddressRepository _userAddressRepository;
    private readonly CreditCardService _creditCardService;
    private readonly CreditCardRepository _creditCardsRepository;
    private readonly UserRepository _userRepository;

    public AccountController(AddressService addressService, UserManager<AppIdentityUser> userManager, UserAddressRepository userAddressRepository, CreditCardService creditCardService, CreditCardRepository creditCardsRepository, UserRepository userRepository)
    {
        _addressService = addressService;
        _userManager = userManager;
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
    public async Task<IActionResult> Edit(EditUserViewModel model)
    {
        AppIdentityUser user = await _userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
        if (user != null)
        {
            if (ModelState.IsValid)
            {
                user.Email = model.Email;
                user.PhoneNumber = model.PhoneNumber;
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
            }
            else 
            {
                ModelState.AddModelError("","Somethin went wrong");
            }

            if (!string.IsNullOrEmpty(model.Email))
            {
                IdentityResult result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                    return RedirectToAction("Index");
                else
                {
                    return View();
                }
              
            }
        }
        return View(user);
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






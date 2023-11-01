using Manero.Models.Entities;
using Manero.Models.Repository;
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


    public AccountController(AddressService addressService, UserManager<AppIdentityUser> userManger, UserAddressRepository userAddressRepository)
    {
        _addressService = addressService;
        _userManger = userManger;
        _userAddressRepository = userAddressRepository;
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



    public async Task<IActionResult> MyAddress(UserAddressesViewModel model)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);


        //if (userId != null)
        //{
        //    var addresses = await _userAddressRepository.GetAllAddressesAsync(userId);

        //    return View(addresses);
        //}

        var viewModel = new UserAddressesViewModel
        {
            UserAddresses = await _userAddressRepository.GetAllAddressesAsync(userId)
        };

            return View(viewModel);
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
                }

            }catch
            {
                ModelState.AddModelError("","This address is already saved on your profile.");
            }


        }

        return View();
    }

}





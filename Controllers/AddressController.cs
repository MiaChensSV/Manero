using Manero.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Manero.Models.Repository;
using Manero.Models.Entities;

namespace Manero.Controllers;

public class AddressController : Controller
{
    private readonly AddressRepository _addressRepository;
    private readonly AppIdentityUser _user;

    public AddressController(AddressRepository addressRepository,  AppIdentityUser user)
    {
        _addressRepository = addressRepository;
        _user = user;
    }

   
}

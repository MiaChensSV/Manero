using Manero.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace Manero.Test.Daniel.Andersson
{
    public class AccountController : Controller
    {
        public IActionResult AddAddress()
        {
            return View();
        }



        [HttpPost]
        public IActionResult AddAddress(AddressViewModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            return View(model);
        }
    }



    public class IfModelStateIsValidRedirectToIndex
    {

        [Fact]
        public void IfAddAddressModelStateIsValidRedirectsToIndex()
        {
            // Arrange
            var controller = new AccountController();

            // Act
            var result = controller.AddAddress(new AddressViewModel());

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }
    }

}

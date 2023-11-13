using Manero.Controllers;
using Manero.Models.Entities;
using Manero.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Moq;
namespace Manero.Test
{
    public class SignUpControllerTests
    {
        private readonly Mock<UserManager<AppIdentityUser>> mockUserManager;
        private readonly Mock<SignInManager<AppIdentityUser>> mockSignInManager;
        private readonly SignUpController controller;

        public SignUpControllerTests()
        {
            mockUserManager = new Mock<UserManager<AppIdentityUser>>(
                new Mock<IUserStore<AppIdentityUser>>().Object,
                null, null, null, null, null, null, null, null);

            mockSignInManager = new Mock<SignInManager<AppIdentityUser>>(
                mockUserManager.Object,
                new Mock<IHttpContextAccessor>().Object,
                new Mock<IUserClaimsPrincipalFactory<AppIdentityUser>>().Object,
                null, null, null, null);

            controller = new SignUpController(mockUserManager.Object, mockSignInManager.Object);
        }

        [Fact]
        public async Task IndexPost_ValidModel_CreatesUserAndRedirectsToHome()
        {
            var model = new SignUpViewModel
            {
                Email = "test@example.com",
                Password = "Password123!",
                FirstName = "Test",
                LastName = "User"
            };

            mockUserManager.Setup(x => x.CreateAsync(It.IsAny<AppIdentityUser>(), It.IsAny<string>()))
                .ReturnsAsync(IdentityResult.Success);

            mockSignInManager.Setup(x => x.SignInAsync(It.IsAny<AppIdentityUser>(), false, null)) // Assuming the third parameter is optional
                             .Returns(Task.CompletedTask);


            var result = await controller.Index(model);

            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
            Assert.Equal("Home", redirectToActionResult.ControllerName);
        }

        [Fact]
        public async Task IndexPost_InvalidModel_ReturnsViewWithModel()
        {
            var model = new SignUpViewModel
            {
                Email = "test@example.com",
                Password = "Password123!",
                FirstName = "Test",
                LastName = "User"
            };

            mockUserManager.Setup(x => x.CreateAsync(It.IsAny<AppIdentityUser>(), It.IsAny<string>()))
                .ReturnsAsync(IdentityResult.Failed(new IdentityError { Description = "Mock error" }));

            controller.ModelState.AddModelError("TestError", "This is a test error");

            var result = await controller.Index(model);

            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.False(controller.ModelState.IsValid);
            Assert.IsAssignableFrom<SignUpViewModel>(viewResult.Model);
        }
    }
}
using Manero.Controllers;
using Manero.Models.Entities;
using Manero.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Manero.Test
{
    public class LoginControllerTests
    {
        private readonly Mock<UserManager<AppIdentityUser>> mockUserManager;
        private readonly Mock<SignInManager<AppIdentityUser>> mockSignInManager;
        private readonly LoginController controller;

        public LoginControllerTests()
        {
            mockUserManager = new Mock<UserManager<AppIdentityUser>>(
                new Mock<IUserStore<AppIdentityUser>>().Object,
                null, null, null, null, null, null, null, null);

            mockSignInManager = new Mock<SignInManager<AppIdentityUser>>(
                mockUserManager.Object,
                new Mock<IHttpContextAccessor>().Object,
                new Mock<IUserClaimsPrincipalFactory<AppIdentityUser>>().Object,
                null, null, null, null);

            controller = new LoginController(mockUserManager.Object, mockSignInManager.Object);
        }

        [Fact]
        public async Task IndexPost_InvalidModelState_ReturnsViewWithModel()
        {
            var model = new LoginViewModel
            {
                Email = "invalid-email",
                Password = "12345",
                RememberMe = false
            };
            controller.ModelState.AddModelError("Email", "Invalid email format");

            var result = await controller.Index(model);

            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.False(controller.ModelState.IsValid);
            Assert.IsType<LoginViewModel>(viewResult.Model);
        }

        [Fact]
        public async Task IndexPost_ValidCredentials_RedirectsToHome()
        {
            var model = new LoginViewModel
            {
                Email = "user@example.com",
                Password = "Password123!",
                RememberMe = true
            };

            var user = new AppIdentityUser { UserName = model.Email, Email = model.Email };
            mockUserManager.Setup(um => um.FindByEmailAsync(model.Email)).ReturnsAsync(user);
            mockSignInManager.Setup(sim => sim.PasswordSignInAsync(user, model.Password, model.RememberMe, false))
                             .ReturnsAsync(Microsoft.AspNetCore.Identity.SignInResult.Success);

            var result = await controller.Index(model);

            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
            Assert.Equal("Home", redirectToActionResult.ControllerName);
        }

        [Fact]
        public async Task IndexPost_InvalidCredentials_ReturnsViewWithModelError()
        {
            var model = new LoginViewModel
            {
                Email = "user@example.com",
                Password = "WrongPassword!",
                RememberMe = false
            };

            var user = new AppIdentityUser { UserName = model.Email, Email = model.Email };
            mockUserManager.Setup(um => um.FindByEmailAsync(model.Email)).ReturnsAsync(user);
            mockSignInManager.Setup(sim => sim.PasswordSignInAsync(user, model.Password, model.RememberMe, false))
                             .ReturnsAsync(Microsoft.AspNetCore.Identity.SignInResult.Failed);

            var result = await controller.Index(model);

            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.False(controller.ModelState.IsValid);
            Assert.Equal("You have entered an invalid username or password!", controller.ModelState[""].Errors[0].ErrorMessage);
            Assert.IsType<LoginViewModel>(viewResult.Model);
        }

        [Fact]
        public void IndexGet_ReturnsViewResultWithLoginViewModel()
        {
            var result = controller.Index();

            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.IsType<LoginViewModel>(viewResult.Model);
        }
    }
}

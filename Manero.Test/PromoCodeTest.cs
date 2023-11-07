using MailChimp.Net.Models;
using Manero.Controllers;
using Manero.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Manero.Test;

public class PromoCodeTest
{
    [Fact]
    public async Task PromoCodesCurrent_ReturnsRedirectToLogin_WhenUserIdIsNull()
    {
        //Arrange
        var mockRepo = new Mock<PromoCodeRepo>();
        var controllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext { User = new ClaimsPrincipal() }
        };
        var controller = new PromoCodeController(mockRepo.Object)
        {
            ControllerContext = controllerContext
        };

        //Act
        var result = await controller.PromoCodesCurrent();

        //Assert 
        var redirectResult = Assert.IsType<RedirectToActionResult>(result);
        Assert.Equal("Index", redirectResult.ActionName);
        Assert.Equal("Login", redirectResult.ControllerName);
    }
}

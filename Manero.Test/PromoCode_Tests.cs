using System.Security.Claims;
using Manero.Context;
using Manero.Controllers;
using Manero.Models.Entities;
using Manero.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Manero.Test
{
    public class PromoCode_Tests
    {
        [Fact]
        public async Task PromoCodesCurrent_UserHasPromocodes_ReturnsViewWithPromocodes()
        {
            // Arrange
            var userId = "testUserId";

            var mockRepo = new Mock<IPromoCodeRepo>();
            mockRepo.Setup(repo => repo.GetUserPromocodesAsync(userId))
                .ReturnsAsync(new List<PromocodesEntity> { new PromocodesEntity() });

            var controller = new PromoCodeController(mockRepo.Object);
            controller.ControllerContext = GetControllerContextWithUserId(userId);

            // Act
            var result = await controller.PromoCodesCurrent();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<PromocodesEntity>>(viewResult.Model);
            Assert.Single(model); 
        }

        [Fact]
        public async Task PromoCodesCurrent_UserHasNoPromocodes_RedirectsToPromoCodeEmpty()
        {
            // Arrange
            var userId = "testUserId";

            var mockRepo = new Mock<IPromoCodeRepo>();
            mockRepo.Setup(repo => repo.GetUserPromocodesAsync(userId))
                .ReturnsAsync(new List<PromocodesEntity>());

            var controller = new PromoCodeController(mockRepo.Object);
            controller.ControllerContext = GetControllerContextWithUserId(userId);

            // Act
            var result = await controller.PromoCodesCurrent();

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("PromoCodeEmpty", redirectToActionResult.ActionName);
            Assert.Equal("PromoCode", redirectToActionResult.ControllerName);
        }

        private ControllerContext GetControllerContextWithUserId(string userId)
        {
            var claims = new Claim[]
            {
            new Claim(ClaimTypes.NameIdentifier, userId)
            };

            var identity = new ClaimsIdentity(claims);
            var user = new ClaimsPrincipal(identity);

            return new ControllerContext
            {
                HttpContext = new DefaultHttpContext { User = user }
            };
        }


        [Fact]
        public async Task AssignPromoCodeToUserAsync_ValidPromoCode_AssignsCode()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) 
                .Options;

            using (var context = new DataContext(options))
            {
                var promoCode = new PromocodesEntity
                {
                    PromocodeTitle = "ValidPromoCode",
                    PromocodeDescription = "Example50",
                    PromocodePercentage = 50,
                    
                };
                context.Promocodes.Add(promoCode);
                context.SaveChanges();
            }

            using (var context = new DataContext(options))
            {
                var promoCodeRepo = new PromoCodeRepo(context);

                // Act
                var result = await promoCodeRepo.AssignPromoCodeToUserAsync("testUserId", "ValidPromoCode");

                // Assert
                Assert.True(result); 
            }
        }

        [Fact]
        public async Task AssignPromoCodeToUserAsync_InvalidPromoCode_ReturnsFalse()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            using (var context = new DataContext(options))
            {
               
            }

            using (var context = new DataContext(options))
            {
                var promoCodeRepo = new PromoCodeRepo(context);

                // Act
                var result = await promoCodeRepo.AssignPromoCodeToUserAsync("testUserId", "InvalidPromoCode");

                // Assert
                Assert.False(result); 
            }
        }
    }
}


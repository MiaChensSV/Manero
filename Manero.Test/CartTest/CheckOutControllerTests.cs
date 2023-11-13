using Manero.Controllers;
using Manero.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;

public class CheckOutControllerTests
{
	private readonly Mock<CheckOutService> _mockCheckOutService;
	private readonly CheckOutController _controller;

	public CheckOutControllerTests()
	{
		_mockCheckOutService = new Mock<CheckOutService>();
		_controller = new CheckOutController(_mockCheckOutService.Object);
	}

	[Fact]
	public void OrderSucess_ReturnsCorrectView()
	{
		// Act
		var result = _controller.OrderSucess() as ViewResult;

		// Assert
		Assert.NotNull(result);
		Assert.True(string.IsNullOrEmpty(result.ViewName) || result.ViewName == "OrderSucess");
	}

	[Fact]
	public void OrderFailed_ReturnsCorrectView()
	{
		// Act
		var result = _controller.OrderFailed() as ViewResult;

		// Assert
		Assert.NotNull(result);
		Assert.True(string.IsNullOrEmpty(result.ViewName) || result.ViewName == "OrderFailed");
	}
}

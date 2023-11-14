using Manero.Models.Entities;
using Manero.ViewModels;

namespace Manero.Test.Niko;

public class CartViewModelTests
{
	[Fact]
	public void CartViewModel_CanBeInstantiated()
	{
		// Act
		var cartViewModel = new CartViewModel();

		// Assert
		Assert.NotNull(cartViewModel);
		Assert.Empty(cartViewModel.OrderDetails);
	}

	[Fact]
	public void CartViewModel_Properties_CanBeSetAndGet()
	{
		// Arrange
		var cartViewModel = new CartViewModel();
		var testArticleNumber = "12345";
		var testProductName = "Test Product";
		var testPrice = 99.99m;

		// Act
		cartViewModel.ArticleNumber = testArticleNumber;
		cartViewModel.ProductName = testProductName;
		cartViewModel.Price = testPrice;

		// Assert
		Assert.Equal(testArticleNumber, cartViewModel.ArticleNumber);
		Assert.Equal(testProductName, cartViewModel.ProductName);
		Assert.Equal(testPrice, cartViewModel.Price);
	}

	[Fact]
	public void CartViewModel_OrderDetails_CanAddAndRemoveItems()
	{
		// Arrange
		var cartViewModel = new CartViewModel();
		var orderDetail = new OrderDetailEntity { /* set properties */ };

		// Act
		cartViewModel.OrderDetails.Add(orderDetail);
		var containsItem = cartViewModel.OrderDetails.Contains(orderDetail);

		// Remove item
		cartViewModel.OrderDetails.Remove(orderDetail);
		var stillContainsItem = cartViewModel.OrderDetails.Contains(orderDetail);

		// Assert
		Assert.True(containsItem);
		Assert.False(stillContainsItem);
	}
}


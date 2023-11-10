var _creditcard = await _userService.GetDefaultCardAsync(userId);
var _address = await _userService.GetDefaultAddressAsync(userId);
if (_creditcard != null)
{
    CheckOutViewModel checkoutViewModel = new()
    {
        UserId = userId,
        OrderDetails = _cartList,
        Subtotal = _subtotal,
        Discount = _discount,
        Total = _subtotal + _discount,
        PaymentMethod = _creditcard.CardNumber,
        ShippingAddress = _address.Address.StreetName + _address.Address.City + _address.Address.PostalCode + _address.Address.Country,
        DeliveryFee = 0,
    };
    await _cartService.SaveToDb(checkoutViewModel);
    return View(checkoutViewModel);
}
else
{
    CheckOutViewModel checkoutViewModel = new()
    {
        UserId = userId,
        DeliveryFee = 0,
        OrderDetails = _cartList,
        Subtotal = _subtotal,
        Discount = _discount,
        Total = _subtotal + _discount,
        PaymentMethod = "",
        ShippingAddress = _address.Address.StreetName + " " + _address.Address.City + " " + _address.Address.PostalCode + " " + _address.Address.Country,
    };
    await _cartService.SaveToDb(checkoutViewModel);
    return View(checkoutViewModel);
}				
	}


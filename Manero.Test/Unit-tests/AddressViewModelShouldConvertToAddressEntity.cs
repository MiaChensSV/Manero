﻿using Manero.Models.Entities;
using Manero.ViewModels;

namespace Manero.Test.Per.Ahlinder;

public static class AddressViewModelConverterTest
{
    [Fact]
    public static void AddressViewModelShouldConvertToAddressEntity()
    {
        //ARRANGE -- PREPARE
        AddressViewModel address = new AddressViewModel()
        {
            StreetName = "Parkgatan 16",
            City = "Laxå",
            PostalCode = "69503",
            Country = "Thailand"
        };

        //ACT -- EXECUTE OPERATIONS
        AddressEntity entity = address;


        //ASSERT -- WHAT I WANT IN RETURN
        Assert.NotNull(entity);
        Assert.IsType<AddressEntity>(entity);
        Assert.IsType<string>(entity.StreetName);
        Assert.IsType<string>(entity.City);
        Assert.IsType<string>(entity.PostalCode);
        Assert.IsType<string>(entity.Country);
        Assert.Equal(address.StreetName, entity.StreetName);
        Assert.Equal(address.PostalCode, entity.PostalCode);
        Assert.Equal(address.Country, entity.Country);
        Assert.Equal(address.City, entity.City);
    }

}

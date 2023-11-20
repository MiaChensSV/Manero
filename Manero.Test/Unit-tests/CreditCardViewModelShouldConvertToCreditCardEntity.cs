using Manero.Models.Entities;
using Manero.ViewModels;

namespace Manero.Test.Daniel.Andersson;

public class CreditCardViewModelConverterTest
{

    [Fact]
    public static void CreditCardViewModelShouldConvertToCreditCardEntity()
    {
        //ARRANGE -- PREPARE

        AddCreditCardViewModel viewModel = new AddCreditCardViewModel()
        {
            CardNumber = "2521 2512 2615 2611",
            CreditCardName = "Anders Andersson",
            CVV = "124",
            ExpireDate = "11/25"
        };

        // ACT -- EXECUTE OPERATIONS
        CreditCardsEntity entity = viewModel;



        //ASSERT -- WHAT I WANT IN RETURN
        Assert.NotNull(entity);
        Assert.IsType<CreditCardsEntity>(entity);
        Assert.IsType<string>(entity.CardNumber);
        Assert.IsType<string>(entity.CreditCardName);
        Assert.IsType<string>(entity.CVV);
        Assert.IsType<string>(entity.ExpireDate);
        Assert.Equal(viewModel.CardNumber, entity.CardNumber);
        Assert.Equal(viewModel.CreditCardName, entity.CreditCardName);
        Assert.Equal(viewModel.CVV, viewModel.CVV);
        Assert.Equal(viewModel.ExpireDate, entity.ExpireDate);
    }


}

using Manero.Models.Entities;
namespace Manero.Test.Daniel.Andersson;

public class CreditCardViewModelConverterTest
{
  
        [Fact]
        public static void CreditCardViewModelShouldConvertToCreditCardEntity()
        {
            //ARRANGE -- PREPARE
            CreditCardsEntity cardEntity = new CreditCardsEntity()
            {
                CardNumber = "1233 4564 1234 1233",
                CreditCardName = "Anders Andersson",
                CVV = "124",
                ExpireDate = "11/25"
            };

            //ACT -- EXECUTE OPERATIONS
            CreditCardsEntity entity = cardEntity;


            //ASSERT -- WHAT I WANT IN RETURN
            Assert.NotNull(entity);
            Assert.IsType<CreditCardsEntity>(entity);
            Assert.Equal(cardEntity.ExpireDate, entity.ExpireDate);
            Assert.Equal(cardEntity.CardNumber, entity.CardNumber);
            Assert.Equal(cardEntity.CVV, entity.CVV);
            Assert.Equal(cardEntity.CreditCardName, entity.CreditCardName);
        }

    
}

//using EShop.Application;
//using EShop.Domain.Exceptions;
//using EShop.Domain.Enums;
//namespace EShop.Application.Tests;

//public class ProvidersAndExceptionsTest
//{
//    [Theory]
//    [InlineData("American Express", "3497 7965 8312 797")]
//    [InlineData("American Express", "345-470-784-783-010")]
//    [InlineData("American Express", "378523393817437")]
//    [InlineData("Visa", "4024-0071-6540-1778")]
//    [InlineData("Visa", "4532 2080 2150 4434")]
//    [InlineData("Visa", "4532289052809181")]
//    [InlineData("MasterCard", "5530016454538418")]
//    [InlineData("MasterCard", "5551561443896215")]
//    [InlineData("MasterCard", "5131208517986691")]
//    public void CreditCardProviders_CheckIfProviderCorrect_ReturnsTrue(CreditCardProvider expected, string number)
//    {
//        switch (number)
//        {
//            case GetCardType(number) == "American Express":
//                    Assert.Equal(CreditCardProvider.AmericanExpress, expected);
//                break;
//        }
//        Assert.Equal(expected, result);
//    }

//    public void GetCardType_CorrectType_ReturnTrue(string expected, string number)
//    {
//        var card = new CreditCardService();

//        var result = card.GetCardType(number);

//        Assert.Equal(expected, result);
//    }
//}
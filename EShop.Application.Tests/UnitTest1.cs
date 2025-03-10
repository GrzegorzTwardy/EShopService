using EShop.Application;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace EShop.Application.Tests;

public class UnitTest1
{
    //
    [Fact]
    public void ValidateCard_CheckCardTooShort_ReturnFalse()
    {
        var creditCardService = new CreditCardService();

        var result = creditCardService.ValidateCard("1234");

        bool expected = false;

        Assert.Equal(expected, result);
    }

    [Fact]
    public void ValidateCard_CheckCardAllDigits_ReturnFalse()
    {
        var creditCardService = new CreditCardService();

        var result = creditCardService.ValidateCard("ashd7364782634ted");

        bool expected = false;

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("American Express", "3497 7965 8312 797")]
    [InlineData("American Express", "345-470-784-783-010")]
    [InlineData("American Express", "378523393817437")]
    [InlineData("Visa", "4024-0071-6540-1778")]
    [InlineData("Visa", "4532 2080 2150 4434")]
    [InlineData("Visa", "4532289052809181")]
    [InlineData("MasterCard", "5530016454538418")]
    [InlineData("MasterCard", "5551561443896215")]
    [InlineData("MasterCard", "5131208517986691")]
    public void GetCardType_CorrectType_ReturnTrue(string expected, string number)
    {
        var card = new CreditCardService();

        var result = card.GetCardType(number);
        
        Assert.Equal(expected, result);
    }
}
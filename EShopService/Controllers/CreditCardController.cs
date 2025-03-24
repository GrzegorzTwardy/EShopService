using Microsoft.AspNetCore.Mvc;
using EShop.Application;
using EShop.Domain.Exceptions;

namespace EShop.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CreditCardController : ControllerBase
{
    private readonly CreditCardService _creditCardService;

    public CreditCardController(CreditCardService creditCardService)
    {
        _creditCardService = creditCardService;
    }

    [HttpPost("validate")]
    public IActionResult ValidateCard([FromBody] string cardNumber)
    {
        try
        {
            bool isValid = _creditCardService.ValidateCard(cardNumber);
            string cardType = _creditCardService.GetCardType(cardNumber);

            return Ok(new
            {
                Status = isValid ? "Valid" : "Invalid",
                Provider = cardType
            });
        }
        catch (CardNumberTooLongException)
        {
            return StatusCode(414, "Card number too long.");
        }
        catch (CardNumberTooShortException)
        {
            return StatusCode(400, "Card number too short.");
        }
        catch (CardNumberIsInvalidException ex)
        {
            if (ex.Message.Contains("unsupported", StringComparison.OrdinalIgnoreCase))
                return StatusCode(406, ex.Message);
            return StatusCode(400, $"Invalid card number: {ex.Message}");
        }
    }
}

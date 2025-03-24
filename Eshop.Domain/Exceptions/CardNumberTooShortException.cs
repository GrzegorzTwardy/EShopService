namespace EShop.Domain.Exceptions;

public class CardNumberTooShortException : Exception
{
    public CardNumberTooShortException() : base("Card number is too short.") { }

    public CardNumberTooShortException(string message) : base(message) { }

    public CardNumberTooShortException(string message, Exception innerException) : base(message, innerException) { }
}
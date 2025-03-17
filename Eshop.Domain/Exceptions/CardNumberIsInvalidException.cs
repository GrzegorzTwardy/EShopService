namespace Eshop.Domain.Exceptions
{
    public class CardNumberIsInvalidException : Exception
    {
        public CardNumberIsInvalidException() : base("Card number is invalid.") { }

        public CardNumberIsInvalidException(string message) : base(message) { }

        public CardNumberIsInvalidException(string message, Exception innerException) : base(message, innerException) { }
    }
}
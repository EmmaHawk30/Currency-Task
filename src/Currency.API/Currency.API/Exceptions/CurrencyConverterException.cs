namespace Currency.API.Exceptions;

[Serializable]
public class CurrencyConverterException : Exception
{
    public CurrencyConverterException()
    {
    }

    public CurrencyConverterException(string message)
        : base(message)
    {
    }

    public CurrencyConverterException(string message, Exception inner)
        : base(message, inner)
    {
    }
}

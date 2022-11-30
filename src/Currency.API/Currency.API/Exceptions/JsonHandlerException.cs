namespace Currency.API.Exceptions;

[Serializable]
public class JsonHandlerException : Exception
{
    public JsonHandlerException()
    {
    }

    public JsonHandlerException(string message)
        : base(message)
    {
    }

    public JsonHandlerException(string message, Exception inner)
        : base(message, inner)
    {
    }
}

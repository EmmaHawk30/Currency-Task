namespace Currency.API.Exceptions;

[Serializable]
public class JsonHelperException : Exception
{
    public JsonHelperException()
    {
    }

    public JsonHelperException(string message)
        : base(message)
    {
    }

    public JsonHelperException(string message, Exception inner)
        : base(message, inner)
    {
    }
}

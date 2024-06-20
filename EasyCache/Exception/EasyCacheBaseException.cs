namespace EasyCache.Error;

public abstract class EasyCacheBaseException: Exception
{
    
    public EasyCacheBaseException() : base()
    {
    }

    public EasyCacheBaseException(string message) : base(message)
    {
    }

    public EasyCacheBaseException(string message, Exception innerException) : base(message, innerException)
    {
    }
}

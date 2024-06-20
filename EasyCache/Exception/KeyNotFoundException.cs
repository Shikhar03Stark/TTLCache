namespace EasyCache.Error;

public class KeyNotFoundException : EasyCacheBaseException
{
    public KeyNotFoundException(object Key): base($"The Key={Key} does not exists"){

    }

    public KeyNotFoundException(object Key, Exception innerException): base($"The Key={Key} does not exists", innerException){

    }

}

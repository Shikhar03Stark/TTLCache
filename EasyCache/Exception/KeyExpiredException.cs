namespace EasyCache.Error;

public class KeyExpiredException: EasyCacheBaseException
{
    public KeyExpiredException(object Key): base($"The Key={Key} has expired"){

    }

    public KeyExpiredException(object Key, Exception innerException): base($"The Key={Key} has expired", innerException){

    }

}

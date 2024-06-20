namespace EasyCache.Entity;

public class Item<K,V>
{
    public K Key { get; private set;}
    public V Value { get; private set;}
    public DateTime TimeToLive { get; private set;}

    public Item(K key, V value, TimeSpan timeToLive)
    {
        Key = key;
        Value = value;
        TimeToLive = DateTime.Now.Add(timeToLive);
    }

    public bool IsExpired()
    {
        return TimeToLive < DateTime.Now;
    }

    public override string ToString()
    {
        return $"Key: {Key}, Value: {Value}, TimeToLive: {TimeToLive}";
    }
}

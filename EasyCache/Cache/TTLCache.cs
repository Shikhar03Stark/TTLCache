using EasyCache.Entity;
using EasyCache.Error;

namespace EasyCache.Cache;

public class TTLCache<K,V> : ICache<K,V> where K : notnull
{
    private readonly Dictionary<K, Item<K,V>> _cache = [];

    private readonly TimeSpan _ttl;

    public TTLCache(TimeSpan TTL){
        _ttl = TTL;
    }

    public void Add(K key, V value)
    {
        _cache.Add(key, new Item<K,V>(key, value, _ttl));
    }

    public void Clear()
    {
        _cache.Clear();
    }

    public V Get(K key)
    {
        if (_cache.ContainsKey(key))
        {
            var item = _cache[key];
            if (item.IsExpired())
            {
                _cache.Remove(key);
                throw new KeyExpiredException(key);
            }
            return item.Value;
        }
        throw new Error.KeyNotFoundException(key);
    }

    public void Remove(K key)
    {
        if (_cache.ContainsKey(key))
        {
            _cache.Remove(key);
        }
    }

    public override string ToString()
    {
        string result = $"Cache (Items={_cache.Count}):\n";
        foreach (var item in _cache)
        {
            result += item.Value.ToString() + "\n";
        }
        return result;
    }
}

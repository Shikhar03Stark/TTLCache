namespace EasyCache.Cache;

public interface ICache<K,V>
{
    public void Add(K key, V value);
    public V Get(K key);
    public void Remove(K key);
    public void Clear();
    public string ToString();

}

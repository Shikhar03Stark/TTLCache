using EasyCache.Cache;
using EasyCache.Error;

namespace EasyCache.Tests;

[TestClass]
public class EasyCacheTests
{
    [TestMethod]
    public void GetFromCacheSuccess()
    {
        // Arrange
        ICache<string, string> cache = new TTLCache<string, string>(TimeSpan.FromSeconds(2));
        cache.Add("key", "value");

        // Act
        var result = cache.Get("key");

        // Assert
        Assert.AreEqual("value", result);

    }

    [TestMethod]
    public void GetFromCacheFail()
    {
        // Arrange
        ICache<string, string> cache = new TTLCache<string, string>(TimeSpan.FromSeconds(2));
        cache.Add("key", "value");

        // Act
        Action act = () => cache.Get("key2");

        // Assert
        Assert.ThrowsException<Error.KeyNotFoundException>(act);

    }

    [TestMethod]
    public void GetFromCacheAfterTTL()
    {
        // Arrange
        ICache<string, string> cache = new TTLCache<string, string>(TimeSpan.FromSeconds(2));
        cache.Add("key", "value");

        // Act
        Task.Delay(3000).Wait();
        Action act = () => cache.Get("key");

        // Assert
        Assert.ThrowsException<KeyExpiredException>(act);

    }
}
using EasyCache.Cache;
using EasyCache.Error;

namespace EasyCache;

public class Program
{
    public static async Task Main(){

        ICache<string, string> fruitColour = new TTLCache<string, string>(TimeSpan.FromSeconds(2));

        fruitColour.Add("apple", "red");
        fruitColour.Add("banana", "yellow");
        fruitColour.Add("grape", "purple");

        Console.WriteLine($"Within TTL: {fruitColour.Get("apple")}");

        try
        {
            Console.WriteLine($"Within TTL: {fruitColour.Get("orange")}");
        }
        catch (Error.KeyNotFoundException e)
        {
            
            Console.WriteLine($"KeyNotFoundException: {e.Message}");
        }

        // Wait for TTL to expire
        Console.WriteLine("Waiting for TTL to expire");
        await Task.Delay(3000);

        try
        {
            Console.WriteLine($"After TTL: {fruitColour.Get("apple")}");
        }
        catch (KeyExpiredException e)
        {
            Console.WriteLine($"KeyExpiredException: {e.Message}");
        }

    } 
}
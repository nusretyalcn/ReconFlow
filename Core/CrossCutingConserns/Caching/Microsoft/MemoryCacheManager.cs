using System.Reflection;
using System.Text.RegularExpressions;
using Core.Utilities.IoC;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;

namespace Core.CrossCutingConserns.Caching.Microsoft;

public class MemoryCacheManager: ICacheManager
{
    private readonly IMemoryCache _memoryCache;

    public MemoryCacheManager()
    {
        _memoryCache = ServiceTool.ServiceProvider.GetService<IMemoryCache>();
    }

    public void Add(string key, object value, int duration)
    {
        _memoryCache.Set(key,value,TimeSpan.FromMinutes(duration));
    }

    public void Remove(string key)
    {
        _memoryCache.Remove(key);
    }

    public void RemoveByPattern(string pattern)
    {
        var fieldInfo = typeof(MemoryCache).GetField("_coherentState", BindingFlags.Instance | BindingFlags.NonPublic);
        var propertyInfo = fieldInfo.FieldType.GetProperty("EntriesCollection", BindingFlags.Instance | BindingFlags.NonPublic);
        var value = fieldInfo.GetValue(_memoryCache);
        var dict = propertyInfo.GetValue(value) as dynamic;
        List<ICacheEntry> cacheCollectionValues = new List<ICacheEntry>();
 
        foreach (var cacheItem in dict)
        {
            ICacheEntry cacheItemValue = cacheItem.GetType().GetProperty("Value").GetValue(cacheItem, null);
 
            cacheCollectionValues.Add(cacheItemValue);
        }
 
        var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
 
        var keyToRemove = cacheCollectionValues.Where(d => regex.IsMatch(d.Key.ToString())).Select(d => d.Key).ToList();
 
        foreach (var key in keyToRemove)
        {
            _memoryCache.Remove(key);
        }
    }

    public bool IsAdd(string key)
    {
        return _memoryCache.TryGetValue(key, out _);
    }

    public object Get(string key)
    {
        return _memoryCache.Get(key);
    }

    public T Get<T>(string key)
    {
        return _memoryCache.Get<T>(key);
    }
}
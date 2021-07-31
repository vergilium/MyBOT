using System;
using System.Collections.Concurrent;
using System.Dynamic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;

namespace MyBOT.Models.Session {
    public class SessionCollection<TItem> where TItem: DynamicObject {
        private readonly MemoryCache _sessionCache = new MemoryCache(new MemoryCacheOptions(){ SizeLimit = 1024 });
        private readonly ConcurrentDictionary<object, SemaphoreSlim> _locks = new ConcurrentDictionary<object, SemaphoreSlim>();
 
        public async Task<TItem> GetOrCreate(object key, Func<Task<TItem>> createItem) {
            TItem cacheEntry;
            if (!_sessionCache.TryGetValue(key, out cacheEntry)) {
                SemaphoreSlim itemLock = _locks.GetOrAdd(key, k => new SemaphoreSlim(1, 1));
                await itemLock.WaitAsync();
                try {
                    if (!_sessionCache.TryGetValue(key, out cacheEntry)) {
                        // Key is not found, get data from function
                        cacheEntry = await createItem();
                        var cacheEntryOptions = new MemoryCacheEntryOptions()
                            .SetSize(1) //Size value per item (eq SizeLimit)
                            .SetPriority(CacheItemPriority.High) // Priority for remove item if size of item was fulled (GC Pressure)
                            .SetSlidingExpiration(TimeSpan.FromSeconds(300)) //Stored item for max time, update if used (sec)
                            .SetAbsoluteExpiration(TimeSpan.FromSeconds(3600)); //Delete item after set time. (sec)
                        // Stored data in cache
                        _sessionCache.Set(key, cacheEntry, cacheEntryOptions);
                    }
                }
                catch (Exception ex) {
                    // ignored
                    //Need the make section
                }
                finally {
                    itemLock.Release();
                }
            }
            return cacheEntry;
        }
        
        public async Task<bool> TryAddValue(object key, object value) {
            try {
                SemaphoreSlim itemLock = _locks.GetOrAdd(key, k => new SemaphoreSlim(1, 1));
                await itemLock.WaitAsync();
                
                if (_sessionCache.TryGetValue(key, out TItem data)) {
                    dynamic sObj = data;
                    sObj.Add(value);
                    return true;
                }
                return false;
#pragma warning disable 168
            } catch (Exception ex) {
#pragma warning restore 168
                return false;
            }
        }

        public bool TryGetValue(Object key,  Type type, out object value) {
            try {
                if (_sessionCache.TryGetValue(key, out TItem data)) {
                    dynamic obj = data;
                    foreach (var prop in obj) {
                        if (prop.Key != type.Name.ToLower() || prop.Value == null) continue;
                        value = Convert.ChangeType(prop.Value, type);
                        return true;
                    }
                }
                value = null;
                return false;
            }
#pragma warning disable 168
            catch (Exception ex) {
#pragma warning restore 168
                value = null;
                return false;
            }
        }
    }
}
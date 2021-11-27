using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace IDisposableCache
{
    public class Cache<T> where T : IDisposable
    {
        private readonly Dictionary<int, Tuple<T, DateTime>> _cache = null;

        private readonly int _maxSize = 8;
        private readonly int _timeInterval = 1000;
        private int _elementsInCache = 0;

        private static bool checkForNotify = true;

        public Cache(int maxSize, int timeInterval)
        {
            _maxSize = maxSize;
            _timeInterval = timeInterval;
            _cache = new Dictionary<int, Tuple<T, DateTime>>(_maxSize);

            GC.RegisterForFullGCNotification(90, 90);
            checkForNotify = true;

            Thread thWaitForFullGC = new Thread(new ThreadStart(WaitForFullGCProc));
            thWaitForFullGC.Start();
        }

        public Cache(int maxSize) : this(maxSize, 1500) { }

        public bool Add(int key, T item)
        {
            if (_cache.Count < _maxSize)
            {
                var cacheElem = new Tuple<T, DateTime>(item, DateTime.Now);
                _cache[key] = cacheElem;
                _elementsInCache++;
                return true;
            }

            var successfullyCleared = Clear();
            if (successfullyCleared)
            {
                var cacheElem = new Tuple<T, DateTime>(item, DateTime.Now);
                _cache[key] = cacheElem;
                _elementsInCache++;
                return true;
            }

            return false;
        }

        public T Get(int key)
        {
            if (!_cache.ContainsKey(key))
            {
                throw new KeyNotFoundException("Not found elements with this key");
            }

            // update time of last access to cache 
            _cache[key] = new Tuple<T, DateTime>(_cache[key].Item1, DateTime.Now);
            return _cache[key].Item1;
        }

        public int CacheSize()
        {
            return _cache.Count;
        }

        public int ElementsInCache()
        {
            return _elementsInCache;
        }

        public bool Clear()
        {
            Console.WriteLine("Cache clearing");
            bool successfullyCleared = false;

            foreach (var item in _cache)
            {
                DateTime currTime = DateTime.Now;
                var currElementLifetime = currTime.Subtract(item.Value.Item2);

                // remove if element is "old"
                if (currElementLifetime.TotalMilliseconds >= _timeInterval)
                {
                    item.Value.Item1.Dispose();
                    _cache.Remove(item.Key);
                    _elementsInCache--;
                    successfullyCleared = true;
                }
            }
            return successfullyCleared;
        }

        private void WaitForFullGCProc()
        {
            while (true)
            {
                while (checkForNotify)
                {
                    // Check for a notification of an approaching collection
                    GCNotificationStatus s = GC.WaitForFullGCApproach();
                    if (s == GCNotificationStatus.Succeeded)
                    {
                        OnFullGCApproachNotify();
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        private void OnFullGCApproachNotify()
        {
            Clear();
            GC.Collect();
        }
    }

}

using System;
using System.Collections.Concurrent;

namespace MiniMe.Core
{
    public static class MiniMeService
    {
        private static readonly ConcurrentDictionary<Type, object> _services = new ConcurrentDictionary<Type, object>();

        public static void Add<T>(T service)
        {
            if (_services.ContainsKey(typeof(T)))
                return;

            _services.TryAdd(typeof(T), service);
        }

        public static T Remove<T>()
        {
            if (_services.TryRemove(typeof(T), out var service))
            {
                return (T)service;
            }

            return default;
        }

        public static T Get<T>()
        {
            if (_services.TryGetValue(typeof(T), out var service))
                return (T)service;

            return default;
        }
    }
}

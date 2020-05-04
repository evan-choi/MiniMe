using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;

namespace MiniMe.Core.Mapper
{
    public static class ObjectMapper
    {
        private static readonly ConcurrentDictionary<Type, PropertyProvider[]> _contracts =
            new ConcurrentDictionary<Type, PropertyProvider[]>();

        private static readonly ConcurrentDictionary<MappingDirection, PropertyMap[]> _mappingTables =
            new ConcurrentDictionary<MappingDirection, PropertyMap[]>();

        private static readonly MethodInfo _mapGenericMethod;

        static ObjectMapper()
        {
            _mapGenericMethod = typeof(ObjectMapper).GetMethods()
                .Single(m => m.IsGenericMethod && m.GetGenericArguments().Length == 2);
        }

        public static IEnumerable<T> Map<T>([NotNull] IEnumerable<object> source) where T : class, new()
        {
            if (source == null)
                return Enumerable.Empty<T>();

            return source.Select(Map<T>);
        }

        public static T Map<T>(object source) where T : class, new()
        {
            if (source == null)
            {
                return null;
            }

            var destination = new T();

            var method = _mapGenericMethod.MakeGenericMethod(source.GetType(), typeof(T));
            method.Invoke(null, new[] { source, destination });

            return destination;
        }

        public static void Map<TSource, TDestination>([NotNull] TSource source, [NotNull] TDestination destination)
        {
            if (typeof(TSource) == typeof(TDestination))
            {
                foreach (var provider in GetProviders<TSource>())
                {
                    var value = provider.Get(source);
                    provider.Set(destination, value);
                }
            }
            else
            {
                foreach (var map in GetMappings<TSource, TDestination>())
                {
                    var value = map.Source.Get(source);
                    map.Destination.Set(destination, value);
                }
            }
        }

        private static IEnumerable<PropertyMap> GetMappings<TSource, TDestination>()
        {
            var direction = new MappingDirection(typeof(TSource), typeof(TDestination));

            if (!_mappingTables.TryGetValue(direction, out PropertyMap[] mappings))
            {
                Dictionary<string, PropertyProvider> srcProviders = GetProviders<TSource>().ToDictionary(p => p.Name);
                Dictionary<string, PropertyProvider> dstProviders = GetProviders<TDestination>().ToDictionary(p => p.Name);

                IEnumerable<(string, Type)> srcPivots = srcProviders.Values.Select(p => (p.Name, p.PropertyType));
                IEnumerable<(string, Type)> dstPivots = dstProviders.Values.Select(p => (p.Name, p.PropertyType));

                mappings = srcPivots
                    .Intersect(dstPivots)
                    .Select(p => new PropertyMap(srcProviders[p.Item1], dstProviders[p.Item1]))
                    .ToArray();

                _mappingTables[direction] = mappings;
            }

            return mappings;
        }

        private static IEnumerable<PropertyProvider> GetProviders<T>()
        {
            var type = typeof(T);

            if (!_contracts.TryGetValue(type, out PropertyProvider[] contract))
            {
                contract = type.GetProperties()
                    .Where(p => (p.GetMethod?.IsPublic ?? false) && (p.SetMethod?.IsPublic ?? false))
                    .Select(p => new PropertyProvider(p))
                    .ToArray();

                _contracts[type] = contract;
            }

            return contract;
        }

        private readonly struct MappingDirection
        {
            public Guid Source { get; }

            public Guid Destination { get; }

            public MappingDirection(Type source, Type destination)
            {
                Source = source.GUID;
                Destination = destination.GUID;
            }
        }

        private readonly struct PropertyProvider
        {
            public string Name { get; }

            public Type PropertyType { get; }

            public DynamicAccessor.Getter Get { get; }

            public DynamicAccessor.Setter Set { get; }

            public PropertyProvider(PropertyInfo propertyInfo)
            {
                Name = propertyInfo.Name;
                PropertyType = propertyInfo.PropertyType;
                Get = DynamicAccessor.CreatePropertyGetter(propertyInfo);
                Set = DynamicAccessor.CreatePropertySetter(propertyInfo);
            }
        }

        private readonly struct PropertyMap
        {
            public PropertyProvider Source { get; }

            public PropertyProvider Destination { get; }

            public PropertyMap(PropertyProvider source, PropertyProvider destination)
            {
                Source = source;
                Destination = destination;
            }
        }
    }
}

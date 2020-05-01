using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Reflection;

namespace MiniMe.Core.Utilities
{
    public static class ResourceManager
    {
        private static string GetFullResourceName(Assembly assembly, string resourceName)
        {
            return $"{assembly.GetName().Name}.Resources.{resourceName}";
        }

        public static Stream GetResourceStream([NotNull] string resourceName)
        {
            var assembly = Assembly.GetCallingAssembly();
            resourceName = GetFullResourceName(assembly, resourceName);

            return assembly.GetManifestResourceStream(resourceName);
        }

        public static byte[] GetResourceBytes([NotNull] string resourceName)
        {
            var assembly = Assembly.GetCallingAssembly();
            resourceName = GetFullResourceName(assembly, resourceName);

            var stream = assembly.GetManifestResourceStream(resourceName) ?? throw new KeyNotFoundException(resourceName);
            using var ms = new MemoryStream();
            stream.CopyTo(ms);

            return ms.ToArray();
        }
    }
}

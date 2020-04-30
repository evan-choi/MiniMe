using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Reflection;

namespace MiniMe.Utilities
{
    internal static class ResourceManager
    {
        private static readonly Assembly _assembly = typeof(ResourceManager).Assembly;

        private static string GetFullResourceName([NotNull] string resourceName)
        {
            return $"MiniMe.Resources.{resourceName}";
        }

        public static Stream GetResourceStream([NotNull] string resourceName)
        {
            resourceName = GetFullResourceName(resourceName);
            return _assembly.GetManifestResourceStream(resourceName);
        }
    }
}

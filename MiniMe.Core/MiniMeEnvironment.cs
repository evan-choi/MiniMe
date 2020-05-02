using System.IO;
using System.Reflection;

namespace MiniMe.Core
{
    public static class MiniMeEnvironment
    {
        public static string DataDirectory { get; }

        static MiniMeEnvironment()
        {
            var assesmblyDirectory = Path.GetDirectoryName(Assembly.GetEntryAssembly()!.Location);

            DataDirectory = Path.Combine(assesmblyDirectory!, "Data");

            if (!Directory.Exists(DataDirectory))
            {
                Directory.CreateDirectory(DataDirectory);
            }
        }

        public static string GetDataFile(string file)
        {
            return Path.Combine(DataDirectory, file);
        }
    }
}

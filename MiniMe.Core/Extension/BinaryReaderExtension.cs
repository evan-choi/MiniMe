using System.IO;

namespace MiniMe.Core.Extension
{
    public static class BinaryReaderExtension
    {
        public static void Skip(this BinaryReader reader, int offset)
        {
            reader.BaseStream.Position += offset;
        }
    }
}

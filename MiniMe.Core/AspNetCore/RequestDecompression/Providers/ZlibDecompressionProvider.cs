using System.IO;
using Ionic.Zlib;

namespace MiniMe.Core.AspNetCore.RequestDecompression
{
    public class ZlibDecompressionProvider : IDecompressionProvider
    {
        public Stream CreateStream(Stream inputStream)
        {
            return new ZlibStream(inputStream, CompressionMode.Decompress);
        }
    }
}

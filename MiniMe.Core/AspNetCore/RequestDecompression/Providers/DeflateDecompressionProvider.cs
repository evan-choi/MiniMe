using System.IO;
using System.IO.Compression;

namespace MiniMe.Core.AspNetCore.RequestDecompression
{
    public class DeflateDecompressionProvider : IDecompressionProvider
    {
        public Stream CreateStream(Stream outputStream)
        {
            return new DeflateStream(outputStream, CompressionMode.Decompress);
        }
    }
}

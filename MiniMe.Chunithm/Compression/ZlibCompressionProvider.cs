using System.IO;
using Ionic.Zlib;
using Microsoft.AspNetCore.ResponseCompression;

namespace MiniMe.Chunithm.Compression
{
    public class ZlibCompressionProvider : ICompressionProvider
    {
        public string EncodingName => "deflate";

        public bool SupportsFlush => true;

        public Stream CreateStream(Stream outputStream)
        {
            return new ZlibStream(outputStream, CompressionMode.Compress);
        }
    }
}

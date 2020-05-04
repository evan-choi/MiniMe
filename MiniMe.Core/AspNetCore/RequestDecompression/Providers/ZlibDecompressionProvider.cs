using System.IO;
using Ionic.Zlib;
using Microsoft.AspNetCore.Http;

namespace MiniMe.Core.AspNetCore.RequestDecompression
{
    public class ZlibDecompressionProvider : RequestDecompressionProvider
    {
        protected override Stream CreateStream(Stream inputStream, IHeaderDictionary headers)
        {
            return new ZlibStream(inputStream, CompressionMode.Decompress);
        }
    }
}

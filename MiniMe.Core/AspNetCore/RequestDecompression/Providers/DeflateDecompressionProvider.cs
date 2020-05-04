using System.IO;
using System.IO.Compression;
using Microsoft.AspNetCore.Http;

namespace MiniMe.Core.AspNetCore.RequestDecompression
{
    public class DeflateDecompressionProvider : RequestDecompressionProvider
    {
        protected override Stream CreateStream(Stream outputStream, IHeaderDictionary headers)
        {
            return new DeflateStream(outputStream, CompressionMode.Decompress);
        }
    }
}

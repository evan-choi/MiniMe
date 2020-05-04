using System.IO;
using Microsoft.AspNetCore.Http;

namespace MiniMe.Core.AspNetCore.RequestDecompression
{
    public interface IDecompressionProvider
    {
        Stream CreateStream(Stream inputStream, IHeaderDictionary requestHeaders);
    }
}

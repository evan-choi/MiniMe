using System.IO;

namespace MiniMe.Core.AspNetCore.RequestDecompression
{
    public interface IDecompressionProvider
    {
        Stream CreateStream(Stream inputStream);
    }
}

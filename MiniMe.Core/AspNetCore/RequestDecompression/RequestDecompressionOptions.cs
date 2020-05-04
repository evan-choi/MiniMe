namespace MiniMe.Core.AspNetCore.RequestDecompression
{
    public sealed class RequestDecompressionOptions
    {
        public DeflateDecompressionProviderCollection Providers { get; } = new DeflateDecompressionProviderCollection();
    }
}

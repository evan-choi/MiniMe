using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace MiniMe.Core.AspNetCore.RequestDecompression
{
    public class RequestDecompressionMiddleware : IMiddleware
    {
        private readonly IDecompressionProvider[] _providers;

        public RequestDecompressionMiddleware(IOptions<RequestDecompressionOptions> options)
        {
            _providers = options.Value.Providers.ToArray();
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var stream = context.Request.Body;

            foreach (var provider in _providers)
            {
                stream = provider.CreateStream(stream);
            }

            MemoryStream decoded = default;

            if (stream != context.Request.Body)
            {
                decoded = new MemoryStream();

                await stream.CopyToAsync(decoded);
                await stream.DisposeAsync();

                decoded.Position = 0;
                context.Request.Body = decoded;
                context.Request.ContentLength = decoded.Length;
            }

            try
            {
                next?.Invoke(context);
            }
            finally
            {
                if (decoded != null)
                {
                    await decoded.DisposeAsync();
                }
            }
        }
    }
}

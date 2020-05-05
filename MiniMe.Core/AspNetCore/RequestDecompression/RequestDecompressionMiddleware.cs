using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
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

            // Kestrel server does not support synchronous I/O
            var bodyFeature = context.Features.Get<IHttpBodyControlFeature>();
            var allowSynchronousIO = bodyFeature.AllowSynchronousIO;
            bodyFeature.AllowSynchronousIO = true;

            foreach (var provider in _providers)
            {
                stream = provider.CreateStream(stream, context.Request.Headers);
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
                await next(context);
            }
            finally
            {
                if (decoded != null)
                {
                    await decoded.DisposeAsync();
                }

                bodyFeature.AllowSynchronousIO = allowSynchronousIO;
            }
        }
    }
}

using System.Threading.Tasks;
using Ionic.Zlib;
using Microsoft.AspNetCore.Http;
using MiniMe.Core.AspNetCore.Middleswares;

namespace MiniMe.Chunithm.Middlewares
{
    public class DecompressionMiddleware : MiddlewareBase
    {
        public DecompressionMiddleware(RequestDelegate next) : base(next)
        {
        }

        protected override Task BeforeInvoke(HttpContext context)
        {
            context.Request.Body = new ZlibStream(context.Request.Body, CompressionMode.Decompress);
            return Task.CompletedTask;
        }
    }
}

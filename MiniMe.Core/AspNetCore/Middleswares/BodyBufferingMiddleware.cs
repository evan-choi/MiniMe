using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MiniMe.Core.AspNetCore.Middleswares
{
    public sealed class BodyBufferingMiddleware
    {
        private readonly RequestDelegate _next;

        public BodyBufferingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                context.Request.EnableBuffering();
            }
            finally
            {
                await _next(context);
            }
        }
    }
}

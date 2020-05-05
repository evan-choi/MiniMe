using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MiniMe.Core.AspNetCore.Middleswares;

namespace MiniMe.Chunithm.Middlewares
{
    public class QuirksMiddleware : MiddlewareBase
    {
        public QuirksMiddleware(RequestDelegate next) : base(next)
        {
        }

        protected override Task BeforeInvoke(HttpContext context)
        {
            if (!context.Request.Headers.ContainsKey("x-debug"))
            {
                context.Request.Headers["Accept-Encoding"] = "deflate";
            }

            return Task.CompletedTask;
        }
    }
}

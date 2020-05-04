using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MiniMe.Core.AspNetCore.Middleswares
{
    public sealed class BodyBufferingMiddleware : MiddlewareBase
    {
        public BodyBufferingMiddleware(RequestDelegate next) : base(next)
        {
        }

        protected override Task BeforeInvoke(HttpContext context)
        {
            context.Request.EnableBuffering();

            return Task.CompletedTask;
        }
    }
}

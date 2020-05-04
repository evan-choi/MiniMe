using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MiniMe.Core.AspNetCore.Middleswares
{
    public abstract class MiddlewareBase
    {
        private readonly RequestDelegate _next;

        protected MiddlewareBase(RequestDelegate next)
        {
            _next = next;
        }

        public virtual async Task Invoke(HttpContext context)
        {
            await BeforeInvoke(context);
            await Next(context);
            await AfterInvoke(context);
        }

        protected async Task Next(HttpContext context)
        {
            await _next(context);
        }

        protected virtual Task BeforeInvoke(HttpContext context)
        {
            return Task.CompletedTask;
        }

        protected virtual Task AfterInvoke(HttpContext context)
        {
            return Task.CompletedTask;
        }
    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MiniMe.Core.AspNetCore.Middleswares;

namespace MiniMe.Core.AspNetCore.Hosting
{
    public abstract class HostStartupBase
    {
        public virtual void Configure(IApplicationBuilder app)
        {
            app.UseRouting();
            app.UseMiddleware<BodyBufferingMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public virtual void ConfigureServices(IServiceCollection services)
        {
            services
                .Configure<ConsoleLifetimeOptions>(o => o.SuppressStatusMessages = true)
                .AddControllers(ConfigureControllers)
                .AddNewtonsoftJson(ConfigureJson);
        }

        protected virtual void ConfigureControllers(MvcOptions options)
        {
        }

        protected virtual void ConfigureJson(MvcNewtonsoftJsonOptions options)
        {
        }
    }
}

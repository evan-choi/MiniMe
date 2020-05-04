using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using MiniMe.Chunithm.Compression;
using MiniMe.Chunithm.Data;
using MiniMe.Chunithm.Middlewares;
using MiniMe.Core;
using MiniMe.Core.AspNetCore.Hosting;
using MiniMe.Core.Repositories;

namespace MiniMe.Chunithm
{
    public class ChunithmStartup : HostStartupBase
    {
        public override void Configure(IApplicationBuilder app)
        {
            app.UseMiddleware<QuirksMiddleware>();
            app.UseMiddleware<DecompressionMiddleware>();
            app.UseResponseCompression();

            base.Configure(app);
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            services
                .AddDbContext<ChunithmContext>()
                .AddSingleton(MiniMeService.Get<IAimeService>())
                .AddResponseCompression(o =>
                {
                    o.Providers.Add<ZlibCompressionProvider>();
                });

            base.ConfigureServices(services);
        }

        protected override void ConfigureJson(MvcNewtonsoftJsonOptions options)
        {
            //options.SerializerSettings.Converters.Add(new PrimitiveToStringConverter());
            options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
        }
    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using MiniMe.Core.AspNetCore.RequestDecompression;
using MiniMe.Core.AspNetCore.Hosting;
using MiniMe.Core.AspNetCore.Mvc.Formatters;

namespace MiniMe.Billing
{
    public class BillingStartup : HostStartupBase
    {
        public override void Configure(IApplicationBuilder app)
        {
            app.UseRequestDecompression();

            base.Configure(app);
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddRequestDecompression(o =>
            {
                o.Providers.Add<DeflateDecompressionProvider>();
            });

            base.ConfigureServices(services);
        }

        protected override void ConfigureControllers(MvcOptions options)
        {
            options.InputFormatters.Insert(0, new FormInputFormatter
            {
                SupportedMediaTypes = { "application/octet-stream" }
            });

            options.OutputFormatters.Insert(0, new FormOutputFormatter());
        }
    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using MiniMe.Core.AspNetCore.RequestDecompression;
using MiniMe.Core.AspNetCore.Hosting;
using MiniMe.Core.AspNetCore.Mvc.Formatters;
using MiniMe.Core.Utilities;

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
            byte[] billingKey = ResourceManager.GetResourceBytes("billing.key");

            services.AddSingleton(new BillingCryptoService(billingKey));

            services.AddRequestDecompression(o =>
            {
                o.Providers.Add<DeflateDecompressionProvider>();
            });

            base.ConfigureServices(services);
        }

        protected override void ConfigureControllers(MvcOptions options)
        {
            options.InputFormatters.Insert(0, new FormInputFormatter(true));
            options.OutputFormatters.Insert(0, new FormOutputFormatter(true));
        }
    }
}

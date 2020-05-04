using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using MiniMe.Core;
using MiniMe.Core.AspNetCore.Hosting;
using MiniMe.Core.AspNetCore.Mvc.Formatters;
using MiniMe.Core.AspNetCore.RequestDecompression;
using MiniMe.Core.Repositories;

namespace MiniMe.AllNet
{
    public class AllNetStartup : HostStartupBase
    {
        public override void Configure(IApplicationBuilder app)
        {
            app.UseRequestDecompression();
            base.Configure(app);
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(MiniMeService.Get<ISwitchBoardService>());

            services.AddRequestDecompression(o =>
            {
                o.Providers.Add<Base64DecompressionProvider>();
                o.Providers.Add<ZlibDecompressionProvider>();
            });

            base.ConfigureServices(services);
        }

        protected override void ConfigureControllers(MvcOptions options)
        {
            options.InputFormatters.Insert(0, new FormInputFormatter());

            options.OutputFormatters.Insert(0, new FormOutputFormatter
            {
                SupportedEncodings = { Encoding.GetEncoding(932) }
            });
        }
    }
}

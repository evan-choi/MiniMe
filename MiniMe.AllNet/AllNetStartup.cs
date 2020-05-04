using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using MiniMe.Core;
using MiniMe.Core.AspNetCore.Hosting;
using MiniMe.Core.AspNetCore.Mvc.Formatters;
using MiniMe.Core.Repositories;

namespace MiniMe.AllNet
{
    public class AllNetStartup : HostStartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);
            services.AddSingleton(MiniMeService.Get<ISwitchBoardService>());
        }

        protected override void ConfigureControllers(MvcOptions options)
        {
            options.InputFormatters.Insert(0, new FormInputFormatter());
            options.OutputFormatters.Insert(0, new FormOutputFormatter());
        }
    }
}

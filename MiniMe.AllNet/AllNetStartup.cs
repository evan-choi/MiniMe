using Microsoft.AspNetCore.Mvc;
using MiniMe.Core.AspNetCore.Hosting;
using MiniMe.Core.AspNetCore.Mvc.Formatters;

namespace MiniMe.AllNet
{
    public class AllNetStartup : HostStartupBase
    {
        protected override void ConfigureControllers(MvcOptions options)
        {
            options.InputFormatters.Insert(0, new FormInputFormatter());
            options.OutputFormatters.Insert(0, new FormOutputFormatter());
        }
    }
}

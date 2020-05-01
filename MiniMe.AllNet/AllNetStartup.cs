using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using MiniMe.Core.AspNetCore.Hosting;
using MiniMe.Core.AspNetCore.Mvc.ModelBinding.Binders;

namespace MiniMe.AllNet
{
    public class AllNetStartup : HostStartupBase
    {
        protected override void ConfigureControllers(MvcOptions options)
        {
            options.ModelBinderProviders.Insert(0, new Base64FormModelBinderProvider());
        }
    }
}

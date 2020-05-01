using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace MiniMe.Core.AspNetCore.Hosting
{
    public abstract class HostServerBase<TStartup> : ServerBase
        where TStartup : HostStartupBase
    {
        protected HostServerBase(IPEndPoint endPoint) : base(endPoint)
        {
        }

        public override Task RunAsync()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureWebHostDefaults(ConfigureWebHostDefaults)
                .UseSerilog(Logger)
                .Build()
                .RunAsync();
        }

        protected virtual void ConfigureWebHostDefaults(IWebHostBuilder webBuilder)
        {
            webBuilder
                .UseKestrel(ConfigureKestrel)
                .UseStartup<TStartup>();
        }

        protected virtual void ConfigureKestrel(KestrelServerOptions options)
        {
            options.Listen(EndPoint);
        }
    }
}

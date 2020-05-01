using System.Net;
using Microsoft.AspNetCore.Hosting;
using MiniMe.Core;
using MiniMe.Core.AspNetCore.Hosting;

namespace MiniMe.AllNet
{
    [LoggerName("\u001b[38;5;3mAllNet")]
    public sealed class AllNetServer : HostServerBase<AllNetStartup>
    {
        public AllNetServer(IPEndPoint endPoint) : base(endPoint)
        {
        }

        protected override void ConfigureWebHostDefaults(IWebHostBuilder webBuilder)
        {
            webBuilder
                .UseKestrel(o => o.Listen(EndPoint))
                .UseStartup<AllNetStartup>();
        }
    }
}

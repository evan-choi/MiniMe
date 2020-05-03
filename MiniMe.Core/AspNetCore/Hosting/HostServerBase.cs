using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace MiniMe.Core.AspNetCore.Hosting
{
    public abstract class HostServerBase<TStartup> : ServerBase where TStartup : HostStartupBase
    {
        private CancellationTokenSource _cancellationTokenSource;

        protected HostServerBase(IPEndPoint endPoint) : base(endPoint)
        {
        }

        public override void Start()
        {
            OnInitialize();

            _cancellationTokenSource = new CancellationTokenSource();

            Host.CreateDefaultBuilder()
                .ConfigureWebHostDefaults(ConfigureWebHostDefaults)
                .UseSerilog(Logger)
                .Build()
                .RunAsync(_cancellationTokenSource.Token)
                .Wait(_cancellationTokenSource.Token);

            OnShutdown();
        }

        public override void Stop()
        {
            _cancellationTokenSource?.Cancel();
            _cancellationTokenSource = null;
        }

        protected virtual void OnInitialize()
        {
        }

        protected virtual void OnShutdown()
        {
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

using System.Net;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using MiniMe.Core;
using MiniMe.Core.AspNetCore.Hosting;
using MiniMe.Core.Utilities;

namespace MiniMe.Billing
{
    [LoggerName("\u001b[38;5;4mBilling")]
    public sealed class BillingServer : HostServerBase<DefaultHostStartup>
    {
        public BillingServer(IPEndPoint endPoint) : base(endPoint)
        {
        }

        protected override void ConfigureKestrel(KestrelServerOptions options)
        {
            options.Listen(EndPoint, listneOptions =>
            {
                byte[] pfx = ResourceManager.GetResourceBytes("server.pfx");
                var pfxCert = new X509Certificate2(pfx, "minime");

                listneOptions.UseHttps(pfxCert);
            });
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MiniMe.AimeDb;
using MiniMe.AllNet;
using MiniMe.Core;
using MiniMe.Core.AspNetCore.Extensions;
using MiniMe.Core.Extension;
using MiniMe.Core.Models;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;

namespace MiniMe
{
    public static class Program
    {
        public static async Task<int> Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .MinimumLevel.Override("Microsoft.AspNetCore.Hosting", LogEventLevel.Information)
                .MinimumLevel.Override("Microsoft.EntityFrameworkCore.Database.Command", LogEventLevel.Warning)
                .Enrich.FromLogContext()
                .WriteTo.Console(theme: AnsiConsoleTheme.Code)
                .CreateLogger();

            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false)
                .Build();

            SwitchBoard.Initialize(
                config.GetValue<string>("Host"),
                config.GetOptions<MiniMePorts>("Port"));

            try
            {
                Log.Information("Starting MiniMe");
                await Task.WhenAll(CreateServers().Select(s => s.RunAsync()));
                return 0;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
                return 1;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        private static IEnumerable<ServerBase> CreateServers()
        {
            var dnsEntry = Dns.GetHostEntry(SwitchBoard.Host);

            if (dnsEntry.AddressList.Length == 0)
                throw new Exception("Dns address not found.");

            var address = dnsEntry.AddressList[0];

            yield return new AimeDbServer(new IPEndPoint(address, SwitchBoard.Ports.AimeDb));
            yield return new AllNetServer(new IPEndPoint(address, SwitchBoard.Ports.AllNet));

            //yield return new BillingServer(new IPEndPoint(address, SwitchBoard.Ports.Billing));
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MiniMe.Aime;
using MiniMe.AllNet;
using MiniMe.Core;
using MiniMe.Core.AspNetCore.Extensions;
using MiniMe.Core.Models;
using MiniMe.Core.Utilities;
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
                .WriteTo.Console(
                    theme: AnsiConsoleTheme.Code,
                    outputTemplate: "[MiniMe {Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}")
                .CreateLogger();

            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false)
                .Build();

            SwitchBoard.Initialize(
                config.GetValue<string>("Host"),
                config.GetOptions<MiniMePorts>("Port"));

            ServerBase[] servers = CreateServers().ToArray();

            try
            {
                var cancellationTokenSource = new CancellationTokenSource();

                ConsoleUtility.HookExit(() =>
                {
                    Log.Information("Terminating..");
                    cancellationTokenSource.Cancel();
                });

                Log.Information("Starting");
                await Task.WhenAll(servers.Select(s => s.RunAsync(cancellationTokenSource.Token)));
                Log.Information("Terminated successfully");

                return 0;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Terminated unexpectedly");
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

            yield return new AimeServer(new IPEndPoint(address, SwitchBoard.Ports.Aime));
            yield return new AllNetServer(new IPEndPoint(address, SwitchBoard.Ports.AllNet));

            //yield return new BillingServer(new IPEndPoint(address, SwitchBoard.Ports.Billing));
        }
    }
}

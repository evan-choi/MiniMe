using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using Microsoft.Extensions.Configuration;
using MiniMe.Aime;
using MiniMe.AllNet;
using MiniMe.Billing;
using MiniMe.Chunithm;
using MiniMe.Core;
using MiniMe.Core.AspNetCore.Extensions;
using MiniMe.Core.Models;
using MiniMe.Core.Repositories;
using MiniMe.Core.Utilities;
using Serilog;
using Serilog.Sinks.SystemConsole.Themes;

namespace MiniMe
{
    public static class Program
    {
        private static ServerBase[] _servers;
        private static bool _terminating;

        private static void Initialize()
        {
            // Encodings

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            // Logger

            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console(
                    theme: AnsiConsoleTheme.Code,
                    outputTemplate: "[MiniMe {Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}")
                .CreateLogger();

            // SwitchBoard

            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false)
                .Build();

            MiniMeService.Add<ISwitchBoardService>(
                new SwitchBoard(
                    config.GetValue<string>("Host"),
                    config.GetOptions<MiniMePorts>("Port")));

            // Console Patch
            ConsoleUtility.HookExit(Terminate);
        }

        public static int Main()
        {
            Initialize();

            _servers = CreateServers().ToArray();

            Log.Information("Starting");

            var exceptinoBag = new ConcurrentBag<Exception>();
            var serverEvent = new CountdownEvent(_servers.Length);

            foreach (var server in _servers)
            {
                var thr = new Thread(() =>
                {
                    try
                    {
                        server.Start();
                    }
                    catch (Exception e)
                    {
                        exceptinoBag.Add(e);
                        Terminate();
                    }
                    finally
                    {
                        if (server is IDisposable disposable)
                        {
                            disposable.Dispose();
                        }

                        serverEvent.Signal();
                    }
                })
                {
                    IsBackground = true
                };

                thr.Start();
            }

            serverEvent.Wait();

            try
            {
                if (exceptinoBag.Count > 0)
                {
                    Log.Fatal(new AggregateException(exceptinoBag), "Terminated unexpectedly");
                    return 1;
                }

                Log.Information("Terminated successfully");
                return 0;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        private static void Terminate()
        {
            if (_terminating)
            {
                return;
            }

            _terminating = true;
            Log.Information("Terminating..");

            foreach (var server in _servers)
            {
                server.Stop();
            }
        }

        private static IEnumerable<ServerBase> CreateServers()
        {
            var switchBoard = MiniMeService.Get<ISwitchBoardService>();
            var dnsEntry = Dns.GetHostEntry(switchBoard.Host);

            if (dnsEntry.AddressList.Length == 0)
                throw new Exception("Dns address not found.");

            var address = dnsEntry.AddressList[0];

            yield return new AimeServer(new IPEndPoint(address, switchBoard.Ports.Aime));
            yield return new AllNetServer(new IPEndPoint(address, switchBoard.Ports.AllNet));
            yield return new ChunithmServer(new IPEndPoint(address, switchBoard.Ports.Chunithm));
            yield return new BillingServer(new IPEndPoint(address, switchBoard.Ports.Billing));
        }
    }
}

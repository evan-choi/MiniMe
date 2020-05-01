using System;
using System.Net;
using System.Threading.Tasks;
using Serilog;
using Serilog.Sinks.SystemConsole.Themes;

namespace MiniMe.Core
{
    public abstract class ServerBase
    {
        private static int _loggerPrefixColor = 3;

        public IPEndPoint EndPoint { get; }

        public ILogger Logger { get; }

        protected ServerBase(IPEndPoint endPoint)
        {
            EndPoint = endPoint ?? throw new ArgumentNullException(nameof(endPoint));

            var color = _loggerPrefixColor++;
            var name = GetType().Name;

            Logger = new LoggerConfiguration()
                .WriteTo.Console(
                    theme: AnsiConsoleTheme.Code,
                    outputTemplate: $"[\u001b[38;5;{color}m{name} {{Timestamp:HH:mm:ss}} {{Level:u3}}] {{Message:lj}}{{NewLine}}{{Exception}}")
                .CreateLogger();
        }

        public abstract Task RunAsync();
    }
}

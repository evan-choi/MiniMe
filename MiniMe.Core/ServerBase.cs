using System;
using System.Net;
using System.Reflection;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;

namespace MiniMe.Core
{
    public abstract class ServerBase
    {
        public IPEndPoint EndPoint { get; }

        public ILogger Logger { get; }

        protected ServerBase(IPEndPoint endPoint)
        {
            EndPoint = endPoint ?? throw new ArgumentNullException(nameof(endPoint));

            var name = GetLoggerName();

            Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .MinimumLevel.Override("Microsoft.AspNetCore.Hosting", LogEventLevel.Information)
                .MinimumLevel.Override("Microsoft.EntityFrameworkCore.Database.Command", LogEventLevel.Warning)
                .Enrich.FromLogContext()
                .WriteTo.Console(
                    theme: AnsiConsoleTheme.Code,
                    outputTemplate: $"[{name} {{Timestamp:HH:mm:ss}} {{Level:u3}}] {{Message:lj}}{{NewLine}}{{Exception}}")
                .CreateLogger();
        }

        private string GetLoggerName()
        {
            var nameAttribute = GetType().GetCustomAttribute<LoggerNameAttribute>();
            return nameAttribute?.Name ?? GetType().Name;
        }

        public abstract void Start();

        public abstract void Stop();
    }
}

using System;
using System.Collections.Generic;
using MiniMe.Core.Models;

namespace MiniMe.Core
{
    public static class SwitchBoard
    {
        public static string Host { get; private set; }

        public static MiniMePorts Ports { get; private set; }

        private static bool _initialized;
        private static Dictionary<string, string> _startupHosts;
        private static Dictionary<string, string> _startupUris;

        public static void Initialize(string host, MiniMePorts ports)
        {
            if (_initialized)
                throw new Exception("Already initialized.");

            _initialized = true;

            Host = host;
            Ports = ports;

            _startupHosts = new Dictionary<string, string>
            {
                ["SDDF"] = $"{host}:{ports.Idz.UserDb.Tcp}"
            };

            _startupUris = new Dictionary<string, string>
            {
                ["SDBT"] = $"http://{host}:{ports.Chunithm}",
                ["SBZV"] = $"http://{host}:{ports.Diva}"
            };
        }

        public static string GetStartupHost(string gameId)
        {
            if (_startupHosts.TryGetValue(gameId, out var result))
                return result;

            return null;
        }

        public static string GetStartupUri(string gameId)
        {
            if (_startupUris.TryGetValue(gameId, out var result))
                return result;

            return null;
        }
    }
}

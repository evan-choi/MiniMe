using System.Collections.Generic;
using MiniMe.Core.Models;
using MiniMe.Core.Repositories;

namespace MiniMe.Core
{
    public class SwitchBoard : ISwitchBoardService
    {
        public string Host { get; }

        public MiniMePorts Ports { get; }

        private readonly Dictionary<string, string> _startupHosts;
        private readonly Dictionary<string, string> _startupUris;

        public SwitchBoard(string host, MiniMePorts ports)
        {
            Host = host;
            Ports = ports;

            _startupHosts = new Dictionary<string, string>
            {
                ["SDDF"] = $"{host}:{ports.Idz.UserDb.Tcp}"
            };

            _startupUris = new Dictionary<string, string>
            {
                ["SDBT"] = $"http://{host}:{ports.Chunithm}/",
                ["SBZV"] = $"http://{host}:{ports.Diva}/"
            };
        }

        public string GetStartupHost(string gameId)
        {
            if (_startupHosts.TryGetValue(gameId, out var result))
                return result;

            return null;
        }

        public string GetStartupUri(string gameId)
        {
            if (_startupUris.TryGetValue(gameId, out var result))
                return result;

            return null;
        }
    }
}

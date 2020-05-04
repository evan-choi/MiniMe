using MiniMe.Core.Models;

namespace MiniMe.Core.Repositories
{
    public interface ISwitchBoardService
    {
        string Host { get; }

        MiniMePorts Ports { get; }

        string GetStartupHost(string gameId);

        string GetStartupUri(string gameId);
    }
}

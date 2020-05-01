using System.Net;
using MiniMe.Core;
using MiniMe.Core.Net;

namespace MiniMe.AimeDb
{
    [LoggerName("\u001b[38;5;5mAimeDb")]
    public class AimeDbServer : TcpServer<AimeDbSession>
    {
        public AimeDbServer(IPEndPoint endPoint) : base(endPoint)
        {
        }

        protected override AimeDbSession CreateSession()
        {
            return new AimeDbSession(Logger);
        }

        protected override void OnListen()
        {
            Logger.Information("Now listening on: {endPoint}", $"tcp://{EndPoint}");
        }

        protected override void OnSessionOpened(AimeDbSession session)
        {
            Logger.Information("{id} Session opened.", session.Id);
        }

        protected override void OnSessionClosed(AimeDbSession session)
        {
            Logger.Information("{id} Session closed.", session.Id);
        }
    }
}

using System.Net;
using System.Threading.Tasks;
using MiniMe.Aime.Data;
using MiniMe.Core;
using MiniMe.Core.Net;

namespace MiniMe.Aime
{
    [LoggerName("\u001b[38;5;5mAime")]
    public class AimeServer : TcpServer<AimeSession>
    {
        private AimeUserRepository _repository;

        public AimeServer(IPEndPoint endPoint) : base(endPoint)
        {
        }

        protected override AimeSession CreateSession()
        {
            return new AimeSession(_repository, Logger);
        }

        protected override void OnListen()
        {
            _repository = new AimeUserRepository();
            Logger.Information("Now listening on: {endPoint}", $"tcp://{EndPoint}");
        }

        protected override void OnShutdown()
        {
            _repository?.Dispose();
            _repository = null;
        }

        protected override void OnSessionOpened(AimeSession session)
        {
            Logger.Information("{id} Session opened.", session.Id);
        }

        protected override void OnSessionClosed(AimeSession session)
        {
            Logger.Information("{id} Session closed.", session.Id);
        }
    }
}

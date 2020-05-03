using System.Net;
using Microsoft.EntityFrameworkCore;
using MiniMe.Aime.Data;
using MiniMe.Core;
using MiniMe.Core.Net;

namespace MiniMe.Aime
{
    [LoggerName("\u001b[38;5;5mAime")]
    public sealed class AimeServer : TcpServer<AimeSession>
    {
        private AimeContext _context;
        private AimeUserRepository _repository;

        public AimeServer(IPEndPoint endPoint) : base(endPoint)
        {
        }

        protected override AimeSession CreateSession()
        {
            return new AimeSession(_repository, Logger);
        }

        protected override void OnInitialize()
        {
            _context = new AimeContext();
            _context.Database.Migrate();

            _repository = new AimeUserRepository(_context);
        }

        protected override void OnShutdown()
        {
            _context?.Dispose();
            _context = null;
            _repository = null;
        }
    }
}

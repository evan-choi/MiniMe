using System;
using System.Net;
using Microsoft.EntityFrameworkCore;
using MiniMe.Aime.Data;
using MiniMe.Core;
using MiniMe.Core.Net;
using MiniMe.Core.Repositories;

namespace MiniMe.Aime
{
    [LoggerName("\u001b[38;5;5mAime")]
    public sealed class AimeServer : TcpServer<AimeSession>, IDisposable
    {
        private AimeContext _context;

        public AimeServer(IPEndPoint endPoint) : base(endPoint)
        {
            _context = new AimeContext();
            _context.Database.Migrate();

            MiniMeService.Add<IAimeService>(_context);
        }

        protected override AimeSession CreateSession()
        {
            return new AimeSession(_context, Logger);
        }

        public void Dispose()
        {
            MiniMeService.Remove<IAimeService>();

            _context?.Dispose();
            _context = null;
        }
    }
}

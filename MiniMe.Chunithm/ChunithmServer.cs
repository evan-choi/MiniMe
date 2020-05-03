using System.Net;
using Microsoft.EntityFrameworkCore;
using MiniMe.Chunithm.Data;
using MiniMe.Core;
using MiniMe.Core.AspNetCore.Hosting;

namespace MiniMe.Chunithm
{
    [LoggerName("\u001b[38;5;6mChunithm")]
    public sealed class ChunithmServer : HostServerBase<DefaultHostStartup>
    {
        private ChunithmContext _context;

        public ChunithmServer(IPEndPoint endPoint) : base(endPoint)
        {
        }

        protected override void OnInitialize()
        {
            _context = new ChunithmContext();
            _context.Database.Migrate();
            
            // TODO: initialize repositories
        }

        protected override void OnShutdown()
        {
            _context?.Dispose();
            _context = null;
        }
    }
}

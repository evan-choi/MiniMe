using System;
using System.Net;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using MiniMe.Chunithm.Data;
using MiniMe.Core;
using MiniMe.Core.AspNetCore.Hosting;

namespace MiniMe.Chunithm
{
    [LoggerName("\u001b[38;5;6mChunithm")]
    public sealed class ChunithmServer : HostServerBase<ChunithmStartup>, IDisposable
    {
        private ChunithmContext _context;

        public ChunithmServer(IPEndPoint endPoint) : base(endPoint)
        {
            _context = new ChunithmContext();
            _context.Database.Migrate();
        }

        protected override void ConfigureKestrel(KestrelServerOptions options)
        {
            options.AllowSynchronousIO = true;
            base.ConfigureKestrel(options);
        }

        public void Dispose()
        {
            _context?.Dispose();
            _context = null;
        }
    }
}

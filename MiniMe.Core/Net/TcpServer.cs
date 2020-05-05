using System;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace MiniMe.Core.Net
{
    public abstract class TcpServer<TSession> : ServerBase
        where TSession : TcpSession
    {
        public bool IsAlive => _socket != null && !(_socket.Poll(1, SelectMode.SelectRead) && _socket.Available == 0);

        private Socket _socket;
        private SocketAsyncEventArgs _socketEventArg;
        private bool _stop;

        private readonly ConcurrentDictionary<Guid, TSession> _sessions = new ConcurrentDictionary<Guid, TSession>();

        protected TcpServer(IPEndPoint endPoint) : base(endPoint)
        {
        }

        public override void Start()
        {
            if (_socket != null)
                throw new InvalidOperationException();

            OnInitialize();

            _socketEventArg = new SocketAsyncEventArgs();
            _socketEventArg.Completed += OnAsyncCompleted;

            _socket = new Socket(EndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            _socket.Bind(EndPoint);
            _socket.Listen(1024);

            Logger.Information("Now listening on: {endPoint}", EndPoint);
            OnListen();

            NextAccept(_socketEventArg);

            while (!_stop && IsAlive)
            {
                Thread.Sleep(1000);
            }

            EnsureShutdown();
        }

        public override void Stop()
        {
            _stop = true;
        }

        private void EnsureShutdown()
        {
            try
            {
                _socket.Shutdown(SocketShutdown.Both);
                _socket.Dispose();
                _socket = null;
            }
            catch (Exception)
            {
                // ignored
            }

            OnShutdown();
        }

        private void OnAsyncCompleted(object sender, SocketAsyncEventArgs e)
        {
            Accept(e);
        }

        private void NextAccept(SocketAsyncEventArgs e)
        {
            e.AcceptSocket = null;

            if (!_socket.AcceptAsync(e))
                Accept(e);
        }

        private void Accept(SocketAsyncEventArgs e)
        {
            if (e.SocketError == SocketError.Success)
            {
                var session = CreateSession();

                session.Connect(e.AcceptSocket);
                session.Disconnected += SessionOnDisconnected;

                RegisterSession(session);

                Logger.Information("{id} Session opened.", session.Id);
                OnSessionOpened(session);

                session.StartReceive();
            }

            NextAccept(e);
        }

        private void SessionOnDisconnected(object sender, EventArgs e)
        {
            if (sender is TSession session)
            {
                session.Disconnected -= SessionOnDisconnected;
                UnregisterSession(session.Id);

                Logger.Information("{id} Session closed.", session.Id);
                OnSessionClosed(session);
            }
        }

        protected virtual void OnInitialize()
        {
        }

        protected virtual void OnListen()
        {
        }

        protected virtual void OnShutdown()
        {
        }

        protected virtual void OnSessionOpened(TSession session)
        {
        }

        protected virtual void OnSessionClosed(TSession session)
        {
        }

        protected virtual TSession CreateSession()
        {
            return Activator.CreateInstance<TSession>();
        }

        private void RegisterSession(TSession session)
        {
            _sessions.TryAdd(session.Id, session);
        }

        private void UnregisterSession(Guid sessionId)
        {
            if (_sessions.TryRemove(sessionId, out var session))
            {
                session.Dispose();
            }
        }
    }
}

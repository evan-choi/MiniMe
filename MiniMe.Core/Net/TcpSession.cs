using System;
using System.Collections.Generic;
using System.Net.Sockets;
using MiniMe.Core.IO;
using MiniMe.Core.Net.Transform;

namespace MiniMe.Core.Net
{
    public class TcpSession : IDisposable
    {
        protected const int bufferSize = 8192;

        public event EventHandler Disconnected;

        public Guid Id { get; }

        private Socket _socket;

        // receive
        private bool _receiving;
        private SocketAsyncEventArgs _receiveEventArg;
        private ByteBuffer _receiveBuffer;

        // packet
        private readonly List<IPacketTransform> _recvTransforms;
        private readonly List<IPacketTransform> _sendTransforms;

        public TcpSession()
        {
            Id = Guid.NewGuid();
            _recvTransforms = new List<IPacketTransform>();
            _sendTransforms = new List<IPacketTransform>();
        }

        protected virtual void OnConnected()
        {
        }

        protected virtual void OnPacketReceived(ReadOnlySpan<byte> packet, DateTime reciveTime)
        {
        }

        protected virtual void OnBadPacketReceived(ReadOnlySpan<byte> packet, DateTime reciveTime, Exception exception)
        {
        }

        protected void AddReceiveTransform(IPacketTransform transform)
        {
            _recvTransforms.Add(transform);
        }

        protected void AddSendTransform(IPacketTransform transform)
        {
            _sendTransforms.Add(transform);
        }

        protected int Send(ReadOnlySpan<byte> packet)
        {
            foreach (var transform in _sendTransforms)
            {
                packet = transform.Transform(ref packet);
            }

            int sent = _socket.Send(packet, SocketFlags.None, out var error);

            if (error != SocketError.Success)
            {
                Disconnect();
            }

            return sent;
        }

        protected int Send(byte[] packet)
        {
            return Send(packet.AsSpan());
        }

        protected int Send(byte[] packet, int offset, int length)
        {
            return Send(packet.AsSpan(offset, length));
        }

        internal void Connect(Socket socket)
        {
            _socket = socket;
            _socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive, true);
            _socket.SetSocketOption(SocketOptionLevel.Tcp, SocketOptionName.NoDelay, true);

            _receiveEventArg = new SocketAsyncEventArgs();
            _receiveEventArg.Completed += OnAsyncCompleted;
            _receiveBuffer = new ByteBuffer(bufferSize);

            OnConnected();
        }

        internal void StartReceive()
        {
            NextReceive();
        }

        private void OnAsyncCompleted(object sender, SocketAsyncEventArgs e)
        {
            switch (e.LastOperation)
            {
                case SocketAsyncOperation.Receive:
                    if (ProcessReceive(e))
                        NextReceive();

                    break;

                case SocketAsyncOperation.Send:
                    break;

                default:
                    throw new InvalidOperationException();
            }
        }

        private void NextReceive()
        {
            if (_receiving)
                return;

            bool process = true;

            while (process)
            {
                process = false;

                try
                {
                    _receiving = true;
                    _receiveEventArg.SetBuffer(_receiveBuffer.Data);

                    if (!_socket.ReceiveAsync(_receiveEventArg))
                    {
                        process = ProcessReceive(_receiveEventArg);
                    }
                }
                catch (ObjectDisposedException)
                {
                }
            }
        }

        private bool ProcessReceive(SocketAsyncEventArgs e)
        {
            int size = e.BytesTransferred;

            if (size > 0)
            {
                ProcessPacket(_receiveBuffer.Data, 0, size);

                if (_receiveBuffer.Length == size)
                {
                    _receiveBuffer.Resize(size * 2);
                }
            }

            _receiving = false;

            if (e.SocketError == SocketError.Success)
            {
                if (size > 0)
                {
                    return true;
                }
            }

            Disconnect();

            return false;
        }

        private void ProcessPacket(byte[] packet, int offset, int size)
        {
            var reciveTime = DateTime.Now;
            ReadOnlySpan<byte> buffer = packet.AsSpan(offset, size);

            try
            {
                foreach (var transform in _recvTransforms)
                {
                    buffer = transform.Transform(ref buffer);
                }
            }
            catch (Exception e)
            {
                OnBadPacketReceived(packet.AsSpan(offset, size), reciveTime, e);
                return;
            }

            OnPacketReceived(buffer, reciveTime);
        }

        private void Disconnect()
        {
            if (_socket == null)
                return;

            try
            {
                _socket.Shutdown(SocketShutdown.Both);
            }
            catch (Exception e) when (e is SocketException || e is ObjectDisposedException)
            {
            }

            _socket.Close();
            _socket.Dispose();

            Disconnected?.Invoke(this, EventArgs.Empty);
        }

        public void Dispose()
        {
            if (_socket != null)
            {
                Disconnect();
            }

            _socket = null;
        }
    }
}

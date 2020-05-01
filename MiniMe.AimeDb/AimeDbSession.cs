using System;
using System.Security.Cryptography;
using System.Text;
using MiniMe.AimeDb.Protocols;
using MiniMe.Core.Extension;
using MiniMe.Core.IO;
using MiniMe.Core.Net;
using MiniMe.Core.Net.Transform;
using Serilog;

namespace MiniMe.AimeDb
{
    public sealed class AimeDbSession : TcpSession
    {
        private readonly ILogger _logger;

        private ByteBuffer _incompleteFrame;

        public AimeDbSession(ILogger logger)
        {
            _logger = logger;

            AddReceiveTransform(_decryptor);
            AddSendTransform(_encryptor);
        }

        protected override void OnBadPacketReceived(ReadOnlySpan<byte> packet, DateTime recivedTime, Exception exception)
        {
            const string message = "{id} Bad packet received.\nPacket({length}): {packet}";

            byte[] packetBin = packet.ToArray();
            var packetStr = string.Join(", ", packetBin);

            if (exception != null)
            {
                _logger?.Warning(exception, message, Id, packet.Length, packetStr);
            }
            else
            {
                _logger?.Warning(message, Id, packet.Length, packetStr);
            }
        }

        protected override void OnPacketReceived(ReadOnlySpan<byte> packet, DateTime reciveTime)
        {
            while (true)
            {
                if (_incompleteFrame != null)
                {
                    int incompleteLength = _incompleteFrame.Length;

                    _incompleteFrame.Resize(incompleteLength + packet.Length);
                    packet.CopyTo(_incompleteFrame.Data.AsSpan(incompleteLength));

                    packet = _incompleteFrame.Data;
                    _incompleteFrame = null;
                }

                if (packet.Length < 8)
                {
                    _incompleteFrame = new ByteBuffer(packet.ToArray());
                    return;
                }

                var magic = packet.Read<ushort>(0);

                if (magic != 0xa13e)
                {
                    throw new InvalidOperationException($"Invalid magic 0x{magic:X}({magic})");
                }

                var frameLength = packet.Read<ushort>(6);

                if (packet.Length < frameLength)
                {
                    _incompleteFrame = new ByteBuffer(packet.ToArray());
                    return;
                }

                OnFrameReceived(packet.Slice(0, frameLength), reciveTime);

                if (packet.Length > frameLength)
                {
                    packet = packet.Slice(frameLength);
                    continue;
                }

                break;
            }
        }

        private void OnFrameReceived(ReadOnlySpan<byte> packet, DateTime reciveTime)
        {
            var duration = DateTime.Now - reciveTime;

            var request = Decoder.Decode(ref packet);
            var response = HandleRequest(request);

            _logger?.Information("{id} Response {@response} in {ms:0.0000}ms", Id, response, duration.TotalMilliseconds);

            if (response != null)
            {
                ReadOnlySpan<byte> reply = Encoder.Encode(response);

                Send(reply);
            }
        }

        // TODO: refactoring
        private AimeResponse HandleRequest(AimeRequest request)
        {
            _logger?.Information("{id} Request {@request} received.", Id, request);

            switch (request)
            {
                case HelloRequest _:
                    return new HelloResponse { Status = 1 };

                case GoodbyeRequest _:
                    return null;
            }

            throw new InvalidOperationException();
        }

        #region Crypto
        private static readonly IPacketTransform _decryptor;
        private static readonly IPacketTransform _encryptor;

        static AimeDbSession()
        {
            var aes = new RijndaelManaged
            {
                BlockSize = 128,
                Key = Encoding.UTF8.GetBytes("Copyright(C)SEGA"),
                Mode = CipherMode.ECB,
                Padding = PaddingMode.Zeros
            };

            _decryptor = new CryptoPacketTransform(aes.CreateDecryptor());
            _encryptor = new CryptoPacketTransform(aes.CreateEncryptor());
        }
        #endregion
    }
}

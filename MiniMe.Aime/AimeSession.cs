using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using MiniMe.Aime.Data;
using MiniMe.Aime.Protocols;
using MiniMe.Aime.Protocols.Serialization;
using MiniMe.Core.Extension;
using MiniMe.Core.IO;
using MiniMe.Core.Net;
using MiniMe.Core.Net.Transform;
using MiniMe.Core.Utilities;
using Serilog;

namespace MiniMe.Aime
{
    public sealed class AimeSession : TcpSession
    {
        private readonly AimeHandler _handler;
        private readonly ILogger _logger;

        private ByteBuffer _incompleteFrame;

        internal AimeSession(AimeUserRepository repository, ILogger logger)
        {
            _logger = logger;
            _handler = new AimeHandler(this, repository, logger);

            AddReceiveTransform(new CryptoPacketTransform(_decryptor, true));
            AddSendTransform(new CryptoPacketTransform(_encryptor));
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

                if (packet.Length < Marshal.SizeOf<AimeHeader>())
                {
                    _incompleteFrame = new ByteBuffer(packet.ToArray());
                    return;
                }

                var header = packet.Read<AimeHeader>();

                if (header.Id != AimeHeader.MagicId)
                {
                    throw new InvalidOperationException($"Invalid magic 0x{header.Id:X}({header.Id})");
                }

                if (packet.Length < header.FrameLength)
                {
                    _incompleteFrame = new ByteBuffer(packet.ToArray());
                    return;
                }

                OnFrameReceived(packet.Slice(0, header.FrameLength), reciveTime);

                if (packet.Length > header.FrameLength)
                {
                    packet = packet.Slice(header.FrameLength);
                    continue;
                }

                break;
            }
        }

        private void OnFrameReceived(ReadOnlySpan<byte> packet, DateTime reciveTime)
        {
            var request = AimeDecoder.Decode(ref packet);

            _logger?.Information("{id} Request {@request} received.", Id, request);

            var response = _handler.Dispatch(request);

            if (response != null)
            {
                Send(AimeEncoder.Encode(response));
            }

            var duration = DateTime.Now - reciveTime;
            _logger?.Information("{id} Response {@response} in {ms:0.0000}ms", Id, response, duration.TotalMilliseconds);
        }

        #region Crypto
        private static readonly ICryptoTransform _decryptor;
        private static readonly ICryptoTransform _encryptor;

        static AimeSession()
        {
            var aes = new RijndaelManaged
            {
                BlockSize = 128,
                Key = HexUtility.HexToBytes("436f7079726967687428432953454741"),
                Mode = CipherMode.ECB,
                Padding = PaddingMode.Zeros
            };

            _decryptor = aes.CreateDecryptor();
            _encryptor = aes.CreateEncryptor();
        }
        #endregion
    }
}

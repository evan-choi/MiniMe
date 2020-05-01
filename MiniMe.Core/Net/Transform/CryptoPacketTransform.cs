using System;
using System.Security.Cryptography;
using MiniMe.Core.IO;

namespace MiniMe.Core.Net.Transform
{
    public class CryptoPacketTransform : IPacketTransform
    {
        private readonly ICryptoTransform _cryptoTransform;
        private ByteBuffer _incompleteBlock;
        private readonly bool _useBuffering;

        public CryptoPacketTransform(ICryptoTransform cryptoTransform, bool useBuffering = false)
        {
            _cryptoTransform = cryptoTransform;
            _useBuffering = useBuffering;
        }

        public ReadOnlySpan<byte> Transform(ref ReadOnlySpan<byte> packet)
        {
            byte[] packetBin;

            if (_useBuffering)
            {
                if (_incompleteBlock != null)
                {
                    int incompleteLength = _incompleteBlock.Length;

                    _incompleteBlock.Resize(incompleteLength + packet.Length);
                    packet.CopyTo(_incompleteBlock.Data.AsSpan(incompleteLength));

                    packet = _incompleteBlock.Data;
                    _incompleteBlock = null;
                }

                int remain = packet.Length % _cryptoTransform.InputBlockSize;

                if (remain > 0)
                {
                    _incompleteBlock = new ByteBuffer(packet.Slice(packet.Length - remain).ToArray());
                }

                packetBin = packet.Slice(0, packet.Length - remain).ToArray();
            }
            else
            {
                packetBin = packet.ToArray();
            }

            return _cryptoTransform.TransformFinalBlock(packetBin, 0, packetBin.Length);
        }
    }
}

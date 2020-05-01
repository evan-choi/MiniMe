﻿using System;
using System.Security.Cryptography;

namespace MiniMe.Core.Net.Transform
{
    public class CryptoPacketTransform : IPacketTransform
    {
        private readonly ICryptoTransform _cryptoTransform;

        public CryptoPacketTransform(ICryptoTransform cryptoTransform)
        {
            _cryptoTransform = cryptoTransform;
        }

        public ReadOnlySpan<byte> Transform(ref ReadOnlySpan<byte> packet)
        {
            byte[] packetBin = packet.ToArray();
            return _cryptoTransform.TransformFinalBlock(packetBin, 0, packetBin.Length);
        }
    }
}

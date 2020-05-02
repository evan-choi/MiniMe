using System;
using System.Collections.Generic;
using MiniMe.Core.Extension;
using MiniMe.Core.Utilities;

namespace MiniMe.AimeDb.Protocols.Serialization
{
    internal static class AimeEncoder
    {
        private static readonly Dictionary<Type, AimeHeader> _headers =
            new Dictionary<Type, AimeHeader>
            {
                [typeof(FeliCaLookupResponse)] = AimeHeader.Create(0x0003, 48),
                [typeof(HelloResponse)] = AimeHeader.Create(0x0065, 20),
                [typeof(CampaignResponse)] = AimeHeader.Create(0x000c, 512),
                [typeof(LookupResponse)] = AimeHeader.Create(0x0006, 304),
                [typeof(Lookup2Response)] = AimeHeader.Create(0x0010, 304),
                [typeof(RegisterResponse)] = AimeHeader.Create(0x0006, 48),
                [typeof(LogResponse)] = AimeHeader.Create(0x000a, 32),
            };

        public static ReadOnlySpan<byte> Encode(AimeResponse response)
        {
            if (!_headers.TryGetValue(response.GetType(), out var header))
            {
                throw new NotSupportedException("Not supported response type");
            }

            Span<byte> packet = new byte[header.FrameLength];
            packet.Write(response.Status, 8);

            switch (response)
            {
                case FeliCaLookupResponse fcLookup:
                    packet.Write(HexUtility.ToBytes(fcLookup.AccessCode), 36);
                    break;

                case LookupResponse lookup:
                    packet.Write(lookup.AimeId ?? -1, 32);
                    packet.Write((byte)lookup.RegisterLevel, 36);
                    break;

                case Lookup2Response lookup2:
                    packet.Write(lookup2.AimeId ?? -1, 32);
                    packet.Write((byte)lookup2.RegisterLevel, 36);
                    break;

                case RegisterResponse register:
                    packet.Write(register.AimeId ?? -1, 32);
                    break;
            }

            return packet;
        }
    }
}

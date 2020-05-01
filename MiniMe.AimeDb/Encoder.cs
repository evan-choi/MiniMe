using System;
using MiniMe.AimeDb.Protocols;
using MiniMe.Core.Extension;

namespace MiniMe.AimeDb
{
    internal static class Encoder
    {
        public static ReadOnlySpan<byte> Encode(AimeResponse response)
        {
            switch (response)
            {
                case HelloResponse hello:
                {
                    Span<byte> packet = CreatePacket(20, 65);
                    packet.Write(hello.Status, 8);
                    return packet;
                }
            }

            throw new NotSupportedException();
        }

        private static Span<byte> CreatePacket(ushort size, ushort opCode)
        {
            Span<byte> packet = new byte[size];

            // header
            packet.Write(new AimeHeader
            {
                Id = AimeHeader.MagicId,
                Id2 = 0x3087,
                OpCode = opCode,
                FrameLength = size
            });

            return packet;
        }
    }
}

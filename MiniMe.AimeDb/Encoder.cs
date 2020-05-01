using System;
using System.Runtime.CompilerServices;
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
            packet.Write((ushort)0xa13e, 0); // Magic?
            packet.Write((ushort)0x3087, 2); // ???
            packet.Write(opCode, 4);
            packet.Write(size, 6);

            return packet;
        }
    }
}

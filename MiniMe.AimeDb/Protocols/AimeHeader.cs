using System.Runtime.InteropServices;

namespace MiniMe.AimeDb.Protocols
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct AimeHeader
    {
        public const ushort MagicId = 0xa13e;
        public const ushort MagicId2 = 0x3087;

        public ushort Id { get; set; } // Magic?

        public ushort Id2 { get; set; } // ???

        public ushort OpCode { get; set; }

        public ushort FrameLength { get; set; }

        public static AimeHeader Create(ushort opCode, ushort size)
        {
            return new AimeHeader
            {
                Id = MagicId,
                Id2 = MagicId2,
                OpCode = opCode,
                FrameLength = size
            };
        }
    }
}

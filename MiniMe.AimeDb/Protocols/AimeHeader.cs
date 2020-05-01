using System.Runtime.InteropServices;

namespace MiniMe.AimeDb.Protocols
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct AimeHeader
    {
        public const ushort MagicId = 0xa13e;

        public ushort Id { get; set; } // Magic?

        public ushort Id2 { get; set; } // ???

        public ushort OpCode { get; set; }

        public ushort FrameLength { get; set; }
    }
}

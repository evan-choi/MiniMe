using System;
using System.Runtime.CompilerServices;

namespace MiniMe.Core.IO
{
    public unsafe class ByteBuffer
    {
        public byte[] Data => _data;

        public int Length => Data.Length;

        private byte[] _data;

        public ByteBuffer(int capacity) : this(new byte[capacity])
        {
        }

        public ByteBuffer(byte[] data)
        {
            _data = data;
        }

        public void Resize(int capacity)
        {
            var destination = new byte[capacity];

            fixed (byte* pSource = _data)
            fixed (byte* pDestination = destination)
            {
                int size = Math.Min(capacity, _data.Length);
                Buffer.MemoryCopy(pSource, pDestination, size, size);
            }

            _data = destination;
        }

        public ReadOnlySpan<byte> AsSpan() => AsSpan(0, _data.Length);

        public ReadOnlySpan<byte> AsSpan(int length) => AsSpan(0, length);

        public ReadOnlySpan<byte> AsSpan(int start, int length)
        {
            return new ReadOnlySpan<byte>(_data, start, length);
        }
    }
}

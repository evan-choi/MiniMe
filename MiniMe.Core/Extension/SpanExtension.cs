using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace MiniMe.Core.Extension
{
    public static class SpanExtension
    {
        public static void Write<TFrom, TTo>(this Span<TFrom> span, TTo value, int offset = 0)
        {
            Unsafe.As<TFrom, TTo>(ref span[offset]) = value;
        }

        public static T Read<T>(this ReadOnlySpan<byte> span, int offset = 0)
        {
            int size = Marshal.SizeOf<T>();
            return Unsafe.ReadUnaligned<T>(ref MemoryMarshal.GetReference(span.Slice(offset, size)));
        }
    }
}

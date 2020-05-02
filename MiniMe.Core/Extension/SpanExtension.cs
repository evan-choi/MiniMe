using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace MiniMe.Core.Extension
{
    public static class SpanExtension
    {
        public static void Write<T>(this Span<T> span, T[] value, int offset = 0)
        {
            value.CopyTo(span.Slice(offset));
        }
        
        public static void Write<TFrom, TTo>(this Span<TFrom> span, TTo value, int offset = 0)
        {
            Unsafe.As<TFrom, TTo>(ref span[offset]) = value;
        }

        public static T Read<T>(this Span<byte> span, int offset = 0)
        {
            return Read<T>((ReadOnlySpan<byte>)span, offset);
        }

        public static T Read<T>(this ReadOnlySpan<byte> span, int offset = 0)
        {
            int size = Marshal.SizeOf<T>();
            return Unsafe.ReadUnaligned<T>(ref MemoryMarshal.GetReference(span.Slice(offset, size)));
        }
    }
}

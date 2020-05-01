using System;
using System.Text;

namespace MiniMe.Core.Extension
{
    public static class ByteArrayExtension
    {
        public static string ToHexString(this ReadOnlySpan<byte> byteSpan)
        {
            var builder = new StringBuilder(byteSpan.Length * 2);

            foreach (var b in byteSpan)
            {
                builder.Append(b.ToString("X2"));
            }

            return builder.ToString();
        }

        public static string ToHexString(this Span<byte> byteSpan)
        {
            return ToHexString((ReadOnlySpan<byte>)byteSpan);
        }

        public static string ToHexString(this byte[] bytes)
        {
            return ToHexString(bytes.AsSpan());
        }
    }
}

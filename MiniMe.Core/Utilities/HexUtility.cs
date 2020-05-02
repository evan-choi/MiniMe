using System;
using System.Globalization;
using System.Text;

namespace MiniMe.Core.Utilities
{
    public static class HexUtility
    {
        public static byte[] ToBytes(string hex)
        {
            var result = new byte[hex.Length / 2];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
            }

            return result;
        }

        public static string ToDecimalString(string hex)
        {
            decimal result = 0;

            for (int i = 0; i < hex.Length; i += 2)
            {
                result = 256 * result + Convert.ToByte(hex.Substring(i, 2), 16);
            }

            return result.ToString(CultureInfo.InvariantCulture);
        }

        public static string ToHexString(ReadOnlySpan<byte> byteSpan)
        {
            var builder = new StringBuilder(byteSpan.Length * 2);

            foreach (var b in byteSpan)
            {
                builder.Append(b.ToString("x2"));
            }

            return builder.ToString();
        }
    }
}

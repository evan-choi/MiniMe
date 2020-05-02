using System;
using System.Numerics;

namespace MiniMe.Core.Utilities
{
    public static class HexUtility
    {
        public static byte[] HexToBytes(ReadOnlySpan<char> hex)
        {
            var result = new byte[hex.Length / 2];

            for (int i = 0; i < result.Length; i++)
            {
                int high = hex[i * 2];
                int low = hex[i * 2 + 1];

                high = (high & 0xf) + ((high & 0x40) >> 6) * 9;
                low = (low & 0xf) + ((low & 0x40) >> 6) * 9;

                result[i] = (byte)((high << 4) | low);
            }

            return result;
        }

        public static string HexToDecimalString(ReadOnlySpan<char> hex)
        {
            return new BigInteger(HexToBytes(hex), true, true).ToString();
        }

        public static string BytesToHex(ReadOnlySpan<byte> bytes)
        {
            Span<char> buffer = stackalloc char[bytes.Length * 2];

            for (int i = 0; i < bytes.Length; i++)
            {
                var b = bytes[i] >> 4;
                buffer[i * 2] = (char)(55 + b + (((b - 10) >> 31) & -7));
                b = bytes[i] & 0xF;
                buffer[i * 2 + 1] = (char)(55 + b + (((b - 10) >> 31) & -7));
            }

            return buffer.ToString();
        }
    }
}

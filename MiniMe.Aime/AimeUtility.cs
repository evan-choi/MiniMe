using System;
using System.Security.Cryptography;
using MiniMe.Core.Extension;

namespace MiniMe.Aime
{
    internal static class AimeUtility
    {
        private static RNGCryptoServiceProvider _rngCsp;

        public static int GenerateCardId()
        {
            _rngCsp ??= new RNGCryptoServiceProvider();

            Span<byte> buffer = stackalloc byte[4];
            _rngCsp.GetBytes(buffer);

            return Math.Abs(buffer.Read<int>());
        }
    }
}

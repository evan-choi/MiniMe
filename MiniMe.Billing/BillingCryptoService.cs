using System;
using System.Security.Cryptography;
using System.Text;
using MiniMe.Core.Extension;
using OpenSSL.PrivateKeyDecoder;

namespace MiniMe.Billing
{
    public sealed class BillingCryptoService
    {
        private readonly RSACryptoServiceProvider _provider;

        public BillingCryptoService(byte[] privateKey)
        {
            var keyString = Encoding.ASCII.GetString(privateKey);

            var decoder = new OpenSSLPrivateKeyDecoder();
            _provider = decoder.Decode(keyString);
        }

        public byte[] Sign(int value, string key)
        {
            Span<byte> buffer = stackalloc byte[15];

            buffer.Write(value);
            buffer.Write(Encoding.ASCII.GetBytes(key), 4);

            return _provider.SignData(buffer.ToArray(), HashAlgorithmName.SHA1.Name);
        }
    }
}

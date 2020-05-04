using System;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace MiniMe.Core.AspNetCore.RequestDecompression
{
    public class Base64DecompressionProvider : RequestDecompressionProvider
    {
        protected override Stream CreateStream(Stream inputStream, IHeaderDictionary headers)
        {
            using var reader = new StreamReader(inputStream);
            var value = reader.ReadToEnd().Trim('\r', '\n', ' ');

            byte[] binary = Convert.FromBase64String(value);

            return new MemoryStream(binary);
        }
    }
}

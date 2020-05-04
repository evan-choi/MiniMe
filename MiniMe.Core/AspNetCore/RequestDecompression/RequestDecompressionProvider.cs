using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;

namespace MiniMe.Core.AspNetCore.RequestDecompression
{
    public abstract class RequestDecompressionProvider : IDecompressionProvider
    {
        public List<string> ContentTypes => _contentTypes ??= new List<string>();

        public List<string> EncodingNames => _encodingNames ??= new List<string>();

        private List<string> _contentTypes;
        private List<string> _encodingNames;

        Stream IDecompressionProvider.CreateStream(Stream inputStream, IHeaderDictionary requestHeaders)
        {
            if (_contentTypes?.Count > 0)
            {
                if (!requestHeaders.TryGetValue(HeaderNames.ContentType, out var contenType))
                {
                    return inputStream;
                }

                if (!_contentTypes.All(v => v.Equals(contenType, StringComparison.OrdinalIgnoreCase)))
                {
                    return inputStream;
                }
            }

            if (_encodingNames?.Count > 0)
            {
                if (!requestHeaders.TryGetValue(HeaderNames.ContentEncoding, out var encoding))
                {
                    return inputStream;
                }

                if (!_encodingNames.All(v => v.Equals(encoding, StringComparison.OrdinalIgnoreCase)))
                {
                    return inputStream;
                }
            }

            return CreateStream(inputStream, requestHeaders);
        }

        protected abstract Stream CreateStream(Stream inputStream, IHeaderDictionary requestHeaders);
    }
}

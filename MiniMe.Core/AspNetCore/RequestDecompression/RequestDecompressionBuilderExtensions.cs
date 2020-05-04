using System;
using Microsoft.AspNetCore.Builder;

namespace MiniMe.Core.AspNetCore.RequestDecompression
{
    public static class RequestDecompressionBuilderExtensions
    {
        public static IApplicationBuilder UseRequestDecompression(this IApplicationBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            return builder.UseMiddleware<RequestDecompressionMiddleware>();
        }
    }
}

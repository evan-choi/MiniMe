using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace MiniMe.Core.AspNetCore.RequestDecompression
{
    public static class RequestDecompressionServicesExtensions
    {
        public static IServiceCollection AddRequestDecompression(this IServiceCollection services, Action<RequestDecompressionOptions> configureOptions)
        {
            services.Configure(configureOptions);
            services.TryAddSingleton<RequestDecompressionMiddleware, RequestDecompressionMiddleware>();

            return services;
        }
    }
}

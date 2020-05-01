using Microsoft.Extensions.Configuration;

namespace MiniMe.Core.AspNetCore.Extensions
{
    public static class ConfigurationExtension
    {
        public static TOptions GetOptions<TOptions>(this IConfiguration configuration, string name) 
            where TOptions : class, new()
        {
            var options = new TOptions();
            configuration.GetSection(name).Bind(options);
            
            return options;
        }
    }
}

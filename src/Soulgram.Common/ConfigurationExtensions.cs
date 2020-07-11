using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Soulgram.Common
{
    public static class ConfigurationExtensions
    {
        public static IConfigurationBuilder AddDefaultConfiguration(this IConfigurationBuilder configurationBuilder, string environmentName)
        {
            configurationBuilder.Sources.Clear();

            configurationBuilder
                .AddJsonFile("appsettings.json", false, false)
                .AddJsonFile($"appsettings.{environmentName}.json", true, false)
                .AddEnvironmentVariables();

            return configurationBuilder;
        }

        public static IHostBuilder SetupConfiguration(this IHostBuilder builder)
        {
            return builder.ConfigureAppConfiguration((hostingContext, config) =>
            {
                var env = hostingContext.HostingEnvironment;

                config
                    .SetBasePath(env.ContentRootPath)
                    .AddDefaultConfiguration(env.EnvironmentName);
            });
        }
    }
}

using Microsoft.Extensions.DependencyInjection;

namespace Soulgram.GraphScripts
{
    public static class Bootstrap
    {
        public static IServiceCollection AddNeo4jDriver(this IServiceCollection services)
        {
            return services;
        }
    }
}


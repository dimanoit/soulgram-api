using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Neo4j.Driver;

namespace Soulgram.DB
{
    public static class Bootstrap
    {
        public static IServiceCollection AddNeo4JDriver(this IServiceCollection services, IConfiguration configuration)
        {
            var options = configuration.GetSection("Neo4j").Get<Neo4JDriverOptions>();

            var authorizationToken = AuthTokens.None;
            if (!string.IsNullOrEmpty(options.Password) && !string.IsNullOrEmpty(options.Username))
            {
                authorizationToken = AuthTokens.Basic(options.Username, options.Password);
            }

            services.TryAddSingleton(GraphDatabase.Driver(options.Uri, authorizationToken));

            return services;
        }
    }
}
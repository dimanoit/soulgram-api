using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Neo4jClient;
using System;

namespace Soulgram.GraphScripts
{
    public static class Bootstrap
    {
        public static IServiceCollection AddNeo4jClient(this IServiceCollection services)
        {
            var dbUrl = new Uri("http://localhost:7474/db/soulgram/");
            services.TryAddSingleton<IGraphClient>(context =>
            {
                var graphClient = new GraphClient(dbUrl, username: "dima", password: "dima1234");
                graphClient.Connect();
                return graphClient;
            });

            return services;
        }
    }
}


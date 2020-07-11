using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Neo4j.Driver;
using Soulgram.Common;
using Soulgram.DB;
using System.Threading.Tasks;

namespace Soulgram.GraphScripts
{
    class Program
    {
        private static readonly ServiceProvider AppServiceProvider;

        static Program()
        {
            //TODO add configuration files to project
            IConfiguration configuration = new ConfigurationBuilder()
                .AddDefaultConfiguration("Development")
                .Build();
            var services = new ServiceCollection();

            // Please register all services here
            services.AddNeo4JDriver(configuration);

            AppServiceProvider = services.BuildServiceProvider();
        }

        public static async Task Main()
        {
            var driver = AppServiceProvider.GetService<IDriver>();
            await driver.VerifyConnectivityAsync();
            Console.WriteLine();
        }
    }
}

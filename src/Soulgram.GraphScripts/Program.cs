using Microsoft.Extensions.DependencyInjection;
using System;
using Neo4jClient;

namespace Soulgram.GraphScripts
{
    class Program
    {
        #region DiRegistration
        private static ServiceProvider _appServiceProvider;
        static Program()
        {
            var services = new ServiceCollection();
            services.AddNeo4jClient();
            _appServiceProvider = services.BuildServiceProvider();
        }

        #endregion

        static void Main(string[] args)
        {
            try
            {
                var graphClient = _appServiceProvider.GetService<IGraphClient>();
                Console.WriteLine("Hello World!");
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.ReadLine();
        }
    }
}

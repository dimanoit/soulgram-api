using Microsoft.Extensions.DependencyInjection;

namespace Soulgram.GraphScripts
{
    class Program
    {
        #region DiRegistration

        private static ServiceProvider _appServiceProvider;

        static Program()
        {
            var services = new ServiceCollection();
            // Please register all services here

            _appServiceProvider = services.BuildServiceProvider();

        }

        #endregion

        public static void Main()
        {
            var helloWorld = new HelloWorldExample("bolt://localhost:7687", "neo4j", "dima");
            helloWorld.PrintGreetingAsync("Kek").GetAwaiter().GetResult();
        }
    }
}

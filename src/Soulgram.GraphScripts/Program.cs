using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Neo4j.Driver;
using Soulgram.Common;
using Soulgram.DB;
using System.Threading.Tasks;
using Soulgram.DB.Entities;
using Soulgram.DB.Repositories;

namespace Soulgram.GraphScripts
{
    class Program
    {
        private static readonly ServiceProvider AppServiceProvider;

        static Program()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddDefaultConfiguration("Development")
                .Build();

            var services = new ServiceCollection();

            // Please register all services here
            services.AddDb(configuration);

            AppServiceProvider = services.BuildServiceProvider();
        }

        public static async Task Main()
        {
            var driver = AppServiceProvider.GetService<IDriver>();
            await driver.VerifyConnectivityAsync();

            //var songRepository = AppServiceProvider.GetService<IRepository<Song>>();
            //var song = await songRepository.GetAsync(10, 0);

            var userRepository = AppServiceProvider.GetService<IRepository<User>>();
            //await userRepository.SetAsync(new User
            //{
            //    Name = "Anna",
            //    Surname = "Cherypantseva",
            //    Login = "Marfaakerman"
            //});
            foreach (var user in await userRepository.GetAsync(10, 1))
            {
                Console.WriteLine(user.Name + " " + user.Surname + " " + user.Login);
            }

            Console.ReadLine();
        }
    }
}

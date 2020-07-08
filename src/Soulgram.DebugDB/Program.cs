using Microsoft.Extensions.Options;
using Soulgram.UserInfoDB;
using Soulgram.UserInfoDB.Entities;
using Soulgram.UserInfoDB.Options;
using Soulgram.UserInfoDB.Repositories;
using Soulgram.UserInfoDB.Repositories.QueriesBuilder;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Soulgram.DebugDB
{
    class Program
    {
        private static async Task Main(string[] args)
        {
            //// Initialize 
            var connectionStr = "User ID=dima;Password=dima1234;Server=localhost;Port=5432;Database=soulgramdb;Integrated Security=true;Pooling=true";
            var options = new DbOptions() { ConnectionString = connectionStr };
            var dbAccessor = new DbAccessor(Options.Create(options));
            var queryBuilder = new PgQueriesBuilder<User>();

            var user = new User
            {
                user_id = 1,
                email = "Chvak",
                user_phone = "fsd"
            };

            var user1 = new User
            {
                user_id = 2,
                email = "Chvak",
                user_phone = "fsd"
            };

            var users = new List<User>() { user, user1 };

            var userRepository = new UserRepository(dbAccessor, queryBuilder);

            //await userRepository.DeleteAsync(1);

            var r = await userRepository.GetAllAsync();

            var k = await userRepository.SaveRangeAsync(users);

            var c = await userRepository.GetAllAsync();

        }
    }
}

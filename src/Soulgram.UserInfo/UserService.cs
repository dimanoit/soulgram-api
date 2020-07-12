using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Neo4j.Driver;
using Soulgram.UserInfo.Models;

namespace Soulgram.UserInfo
{
    public class UserService : IUserInfoService
    {
        private readonly IDriver _driver;

        public UserService(IDriver driver)
        {
            _driver = driver;
        }

        public async Task AddAsync(User user)
        {
            var cypherQuery = new StringBuilder("CREATE (u:User {login: $login, password: $password");
            var queryParameters = new Dictionary<string, object> { { "login", user.Login }, { "password", user.Password } };

            // TODO make a function
            if (!string.IsNullOrEmpty(user.Name))
            {
                cypherQuery.Append(", name: $name");
                queryParameters.Add("$name", user.Name);
            }

            if (!string.IsNullOrEmpty(user.Surname))
            {
                cypherQuery.Append(", surname: $surname");
                queryParameters.Add("$surname", user.Surname);
            }

            if (!string.IsNullOrEmpty(user.Patronymic))
            {
                cypherQuery.Append(", patronymic: $patronymic");
                queryParameters.Add("$patronymic", user.Patronymic);
            }

            var query = new Query(cypherQuery.Append("})").ToString(), queryParameters);
            var session = _driver.AsyncSession();
            var result = await session.WriteTransactionAsync(async tx =>
            {
                var cursor = await tx.RunAsync(query);
                return cursor.ToListAsync();
            });
            await session.CloseAsync();

            var actuallyResult = await result;
        }
    }
}

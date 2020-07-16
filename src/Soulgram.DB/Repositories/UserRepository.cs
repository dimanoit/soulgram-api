using Soulgram.DB.Entities;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Neo4j.Driver;

namespace Soulgram.DB.Repositories
{
    internal class UserRepository : IRepository<User>
    {
        private readonly IQueryRunner<User> _queryRunner;

        public UserRepository(IQueryRunner<User> queryRunner)
        {
            _queryRunner = queryRunner;
        }
        public Task<User> BulkDeleteAsync(User entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<User> BulkSetAsync(IEnumerable<User> entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<User> BulkUpdateAsync(User entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<User> DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<User> GetAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<User> GetAsync(User obj)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAsync(int take, int skip)
        {
            throw new System.NotImplementedException();
        }

        public async Task SetAsync(User user)
        {
            var cypherQuery = new StringBuilder("CREATE (u:User {login: $login})");
            var queryParameters = new Dictionary<string, object> { { "login", user.Login } };

            AddParameter(cypherQuery, new KeyValuePair<string, string>("name", user.Name), queryParameters);
            AddParameter(cypherQuery, new KeyValuePair<string, string>("surname", user.Surname), queryParameters);

            var query = new Query(cypherQuery.ToString(), queryParameters);
            await _queryRunner.RunQueryAsync(query);
        }

        public Task<User> UpdateAsync(User entity)
        {
            throw new System.NotImplementedException();
        }

        private void AddParameter<T>(
            StringBuilder query,
            KeyValuePair<string, T> parameter,
            IDictionary<string, object> parameters)
        {
            var endQuery = "})";
            if (typeof(T).IsValueType || parameter.Value != null)
            {
                query.Replace(endQuery, "," + parameter.Key + endQuery);
                parameters.Add(parameter.Key, parameter.Value);
            }
        }
    }
}

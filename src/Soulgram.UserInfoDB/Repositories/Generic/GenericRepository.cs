using Dapper;
using Soulgram.UserInfoDB.Repositories.QueriesBuilder;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Soulgram.UserInfoDB.Repositories
{
    public abstract class GenericRepository<T, Tid> : IGenericRepository<T, Tid> where T : class
    {
        private readonly IDbAccessor _dbAccessor;
        private readonly IQueriesBuilder<T> _queriesBuilder;
        protected GenericRepository(IDbAccessor dbAccessor, IQueriesBuilder<T> queriesBuilder)
        {
            _dbAccessor = dbAccessor;
            _queriesBuilder = queriesBuilder;
        }

        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken token = default)
        {
            using (var connection = _dbAccessor.Connection)
            {
                var query = _queriesBuilder.BuiltGetAllQuery();
                return await connection.QueryAsync<T>(CancalableQuery(query, token: token));
            }
        }

        public async Task DeleteAsync(Tid id, CancellationToken token = default)
        {
            using (var connection = _dbAccessor.Connection)
            {
                var query = _queriesBuilder.BuiltDeleteQuery();
                await connection.ExecuteAsync(CancalableQuery(query, id, token: token));
            }
        }

        public async Task<T> GetAsync(Tid id, CancellationToken token = default)
        {
            using (var connection = _dbAccessor.Connection)
            {
                var query = _queriesBuilder.BuiltGetQuery();
                return await connection.QuerySingleOrDefaultAsync<T>(CancalableQuery(query, id, token));
            }
        }

        public async Task<int> SaveRangeAsync(IEnumerable<T> list, CancellationToken token = default)
        {
            var inserted = 0;
            var query = _queriesBuilder.BuiltInsertQuery();
            using (var connection = _dbAccessor.Connection)
            {
                inserted += await connection.ExecuteAsync(CancalableQuery(query, list, token));
            }

            return inserted;
        }

        public async Task UpdateAsync(T t, CancellationToken token = default)
        {
            var updateQuery = _queriesBuilder.BuiltUpdateQuery();

            using (var connection = _dbAccessor.Connection)
            {
                await connection.ExecuteAsync(CancalableQuery(updateQuery, t, token));
            }
        }

        public async Task InsertAsync(T t, CancellationToken token = default)
        {
            var insertQuery = _queriesBuilder.BuiltInsertQuery();

            using (var connection = _dbAccessor.Connection)
            {
                await connection.ExecuteAsync(CancalableQuery(insertQuery, t, token));
            }
        }

        private CommandDefinition CancalableQuery(string query, object parameters = null, CancellationToken token = default) =>
            new CommandDefinition(query, parameters: parameters, cancellationToken: token);
    }
}
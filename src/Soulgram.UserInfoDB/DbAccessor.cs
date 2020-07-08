using System.Data;
using Microsoft.Extensions.Options;
using Npgsql;
using Soulgram.UserInfoDB.Options;

namespace Soulgram.UserInfoDB
{
    internal class DbAccessor : IDbAccessor
    {
        private readonly IOptions<DbOptions> _dbOptions;

        public DbAccessor(IOptions<DbOptions> dbOptions)
        {
            _dbOptions = dbOptions;
        }

        public IDbConnection Connection
        {
            get
            {
                var connectionString = _dbOptions.Value.GetConnectionString();
                var connection = new NpgsqlConnection(connectionString);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                return connection;
            }
        }
    }
}

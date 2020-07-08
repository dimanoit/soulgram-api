using Npgsql;
using System;

namespace Soulgram.UserInfoDB.Options
{
    internal static class DbOptionsExtensions
    {
        public static string GetConnectionString(this DbOptions options)
        {
            var connectionString = options.ConnectionString;
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new Exception("DB ConnectionString is empty");
            }

            var csBuilder = new NpgsqlConnectionStringBuilder(connectionString);
            if (options.Timeout.HasValue)
            {
                csBuilder.Timeout = options.Timeout.Value;
            }

            if (options.CommandTimeout.HasValue)
            {
                csBuilder.CommandTimeout = options.CommandTimeout.Value;
            }

            csBuilder.Pooling = options.Pooling;

            return csBuilder.ConnectionString;
        }
    }
}

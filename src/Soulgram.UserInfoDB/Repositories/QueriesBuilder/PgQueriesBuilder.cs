using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;

namespace Soulgram.UserInfoDB.Repositories.QueriesBuilder
{
    internal class PgQueriesBuilder<TEntity> : IQueriesBuilder<TEntity>
    {
        private readonly string tableName;
        private readonly string idComprasion;

        private static IEnumerable<PropertyInfo> entityProperties => typeof(TEntity).GetProperties();
        private readonly PropertyInfo idProperty = entityProperties
                .Where(x => x.Name.Contains("id", System.StringComparison.CurrentCultureIgnoreCase))
                .Single();

        public PgQueriesBuilder()
        {
            var table = typeof(TEntity).GetCustomAttribute<TableAttribute>();
            tableName = $"{table.Schema}.{table.Name}";
            idComprasion = $"{table.Name}.{idProperty.Name} = {idProperty.Name}";
        }


        public string BuiltInsertQuery()
        {
            var columns = string.Join(',', entityProperties.Select(x => x.Name));
            var parameters = string.Join(',', entityProperties.Select(x => $"@{x.Name}"));
            return $"INSERT INTO {tableName} ({columns}) VALUES ({parameters})";
        }

        public string BuiltUpdateQuery()
        {
            var parameters = string.Join(',', entityProperties.Where(x => x != idProperty).Select(x => $"{x.Name}=@{x.Name}"));
            return $"UPDATE {tableName} SET {parameters} WHERE {idComprasion}";
        }

        public string BuiltGetQuery() => $"SELECT * FROM {tableName} WHERE {idComprasion}";
        public string BuiltGetAllQuery() => $"SELECT * FROM {tableName}";
        public string BuiltDeleteQuery() => $"DELETE FROM {tableName} WHERE {idComprasion}";
    }
}

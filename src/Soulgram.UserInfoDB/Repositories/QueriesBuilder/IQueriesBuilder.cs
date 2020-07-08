namespace Soulgram.UserInfoDB.Repositories.QueriesBuilder
{
    public interface IQueriesBuilder<TEntity>
    {
        string BuiltInsertQuery();
        string BuiltUpdateQuery();
        string BuiltDeleteQuery();
        string BuiltGetQuery();
        string BuiltGetAllQuery();
    }
}

using Soulgram.UserInfoDB.Entities;
using Soulgram.UserInfoDB.Repositories.QueriesBuilder;

namespace Soulgram.UserInfoDB.Repositories
{
    public class UserRepository : GenericRepository<User, int>, IUserRepository
    {
        public UserRepository(IDbAccessor dbAccessor, IQueriesBuilder<User> queriesBuilder)
            : base(dbAccessor, queriesBuilder)
        {
        }
    }
}

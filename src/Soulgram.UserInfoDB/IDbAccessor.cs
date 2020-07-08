using System.Data;

namespace Soulgram.UserInfoDB
{
    public interface IDbAccessor
    {
        IDbConnection Connection { get; }
    }
}

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Soulgram.UserInfoDB.Repositories
{
    public interface IGenericRepository<T, TId>
    {
        Task<IEnumerable<T>> GetAllAsync(CancellationToken token = default);
        Task DeleteAsync(TId id, CancellationToken token = default);
        Task<T> GetAsync(TId id, CancellationToken token = default);
        Task<int> SaveRangeAsync(IEnumerable<T> list, CancellationToken token = default);
        Task UpdateAsync(T t, CancellationToken token = default);
        Task InsertAsync(T t, CancellationToken token = default);
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using Soulgram.DB.Entities;

namespace Soulgram.DB.Repositories
{
    public interface IRepository<T> where T : EntityBase
    {
        Task<T> GetAsync(int id);
        Task<T> GetAsync(T obj);
        Task<IEnumerable<T>> GetAsync(int take, int skip);
        Task<T> DeleteAsync(int id);
        Task<T> UpdateAsync(T entity);
        Task SetAsync(T entity);
        Task<T> BulkDeleteAsync(T entity);
        Task<T> BulkSetAsync(IEnumerable<T> entity);
        Task<T> BulkUpdateAsync(T entity);
    }
}

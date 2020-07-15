using System.Collections.Generic;
using System.Threading.Tasks;
using Neo4j.Driver;
using Soulgram.DB.Entities;

namespace Soulgram.DB
{
    public interface IQueryRunner<TEntity> where TEntity : EntityBase
    {
        Task<TEntity> ReadSingleAsync(Query query);
        Task<IEnumerable<TEntity>> Read(Query query);
        Task RunQueryAsync(Query query);
    }
}

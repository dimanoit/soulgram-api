using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Neo4j.Driver;
using Newtonsoft.Json;
using Soulgram.DB.Entities;

namespace Soulgram.DB
{
    internal class Neo4JQueryRunner<T> : IQueryRunner<T> where T : EntityBase
    {
        private readonly IDriver _driver;
        public Neo4JQueryRunner(IDriver driver)
        {
            _driver = driver;
        }

        public Task<IEnumerable<T>> Read(Query query)
        {
            throw new NotImplementedException();
        }

        public async Task<T> ReadSingleAsync(Query query)
        {
            var session = _driver.AsyncSession();
            var result = await session.ReadTransactionAsync(async tx =>
            {
                var cursor = await tx.RunAsync(query);
                return cursor.SingleAsync(record => record[0].As<INode>().Properties);
            });

            await session.CloseAsync();
            var jsonResult = JsonConvert.SerializeObject(await result);
            return JsonConvert.DeserializeObject<T>(jsonResult);
        }

        public Task RunQueryAsync(Query query)
        {
            throw new NotImplementedException();
        }
    }
}

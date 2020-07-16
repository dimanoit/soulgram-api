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

        public async Task<IEnumerable<T>> Read(Query query)
        {
            var jsonResult = await ReadJsonAsync(query,
                cursor => cursor.ToListAsync(record => record[0].As<INode>().Properties));

            return JsonConvert.DeserializeObject<IEnumerable<T>>(jsonResult);
        }

        public async Task<T> ReadSingleAsync(Query query)
        {
            var jsonResult = await ReadJsonAsync(query,
                cursor => cursor.SingleAsync(record => record[0].As<INode>().Properties));

            return JsonConvert.DeserializeObject<T>(jsonResult);
        }

        public Task RunQueryAsync(Query query)
        {
            throw new NotImplementedException();
        }

        private async Task<string> ReadJsonAsync<TKeyValue>(Query query, Func<IResultCursor, Task<TKeyValue>> resultAggregationFunc)
        {
            IAsyncSession session = null;
            TKeyValue result;

            try
            {
                session = _driver.AsyncSession();
                result = await session.ReadTransactionAsync(async tx =>
                {
                    var cursor = await tx.RunAsync(query);
                    return await resultAggregationFunc(cursor);
                });
            }
            finally
            {
                if (session != null)
                {
                    await session.CloseAsync();
                }
            }

            return JsonConvert.SerializeObject(result);
        }
    }
}

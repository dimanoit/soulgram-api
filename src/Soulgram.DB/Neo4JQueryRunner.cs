using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Neo4j.Driver;
using Newtonsoft.Json;
using Soulgram.DB.Entities;

namespace Soulgram.DB
{
    internal sealed class Neo4JQueryRunner<T> : IQueryRunner<T> where T : EntityBase
    {
        // Not implemented IDisposable, because exist possibility
        // to have deadlock with current Dispose pattern
        // implementation in Driver sources
        private readonly IDriver _driver;
        public Neo4JQueryRunner(IDriver driver)
        {
            _driver = driver;
        }

        public async Task<IEnumerable<T>> ReadAsync(Query query)
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

        public async Task RunQueryAsync(Query query)
        {
            var session = _driver.AsyncSession();
            try
            {
                await session.RunAsync(query);
            }
            finally
            {
                await session.CloseAsync();
            }
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

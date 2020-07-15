using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Neo4j.Driver;
using Newtonsoft.Json;
using Soulgram.DB.Entities;

namespace Soulgram.DB.Repositories
{
    internal class SongRepository : IRepository<Song>
    {
        private readonly IQueryRunner<Song> _queryRunner;

        public SongRepository(IQueryRunner<Song> queryRunner)
        {
            _queryRunner = queryRunner;
        }

        public async Task<Song> GetAsync(int id)
        {
            var query = @"MATCH(s: Song)
            WHERE id(s) = $id
            RETURN s";
            var cypherQuery = new Query(query, new { id });

            // ReadTransactionAsync<Song>(Query)
            //TODO extract to generic function or create decorator over iDriver
           Song song = await _queryRunner.ReadSingleAsync(cypherQuery);
           return song;
           //var session = _driver.AsyncSession();
           //var result = await session.ReadTransactionAsync(async tx =>
           //{
           //    var cursor = await tx.RunAsync(cypherQuery);
           //    return cursor.SingleAsync(record => record[0].As<INode>().Properties);
           //});

           //await session.CloseAsync();

           //var actuallyResult = JsonConvert.SerializeObject(await result);
           //var result1 = JsonConvert.DeserializeObject<Song>(actuallyResult);
           //return result1;
        }
        public Task<Song> GetAsync(Song obj)
        {
            throw new NotImplementedException();
        }
        public async Task<IEnumerable<Song>> GetAsync(int take, int skip)
        {
            var query = @"MATCH(s: Song)
            RETURN s
            ORDER BY s.name
            SKIP $skip
            LIMIT $take";

            var cypherQuery = new Query(query, new { take, skip });
            await Task.CompletedTask;
            //TODO extract to generic function or create decorator over iDriver
            return null;
        }

        public Task<Song> DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }
        public Task<Song> UpdateAsync(Song entity)
        {
            throw new System.NotImplementedException();
        }
        public Task<Song> SetAsync(Song entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<Song> BulkDeleteAsync(Song entity)
        {
            throw new System.NotImplementedException();
        }
        public Task<Song> BulkSetAsync(IEnumerable<Song> entity)
        {
            throw new System.NotImplementedException();
        }
        public Task<Song> BulkUpdateAsync(Song entity)
        {
            throw new System.NotImplementedException();
        }
    }
}

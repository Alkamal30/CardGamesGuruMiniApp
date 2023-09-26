using Domain.CardGamesGuruMiniApp.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.CardGamesGuruMiniApp.Repositories
{
    public abstract class BaseRepository<T>
    {
        protected readonly IMongoDatabase database;
        //private readonly string collection;
        private readonly MongoCollectionSettings mongoCollectionSettings;

        protected BaseRepository(IMongoDatabase database, string collection, IOptions<MongoDbOptions> mongoDbOptions)
        {
            this.database = database;
            //this.collection = collection;
            var wcTimeout = TimeSpan.FromMilliseconds(mongoDbOptions.Value.Timeout);
            this.mongoCollectionSettings = new() { WriteConcern = new WriteConcern("majority", wcTimeout, null, true) };
        }

        protected BaseRepository(IMongoDatabase database,IOptions<MongoDbOptions> mongoDbOptions)
        {
            this.database = database;
            var wcTimeout = TimeSpan.FromMilliseconds(mongoDbOptions.Value.Timeout);
            this.mongoCollectionSettings = new() { WriteConcern = new WriteConcern("majority", wcTimeout, null, true) };
        }

        protected IMongoCollection<T> Items => database.GetCollection<T>("games", mongoCollectionSettings);
    }
}

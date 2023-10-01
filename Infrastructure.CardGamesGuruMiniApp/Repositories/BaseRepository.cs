using Domain.CardGamesGuruMiniApp.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Infrastructure.CardGamesGuruMiniApp.Repositories
{
    public abstract class BaseRepository<T>
    {
        protected readonly IMongoDatabase database;
        protected string collection;
        private readonly MongoCollectionSettings mongoCollectionSettings;

        protected BaseRepository(IMongoDatabase database, IOptions<MongoDbOptions> mongoDbOptions)
        {
            this.database = database;
            var wcTimeout = TimeSpan.FromMilliseconds(mongoDbOptions.Value.Timeout);
            this.mongoCollectionSettings = new() { WriteConcern = new WriteConcern("majority", wcTimeout, null, true) };
        }

        protected IMongoCollection<T> Items => database.GetCollection<T>(collection, mongoCollectionSettings);
    }
}
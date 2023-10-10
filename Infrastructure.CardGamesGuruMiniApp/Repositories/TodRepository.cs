using Domain.CardGamesGuruMiniApp.Configuration;
using Infrastructure.CardGamesGuruMiniApp.Models.TodModels;
using Infrastructure.CardGamesGuruMiniApp.Repositories.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Infrastructure.CardGamesGuruMiniApp.Repositories
{
    public class TodRepository : BaseRepository<TodBson>, ITodRepository
    {
        public TodRepository(IMongoDatabase database, IOptions<MongoDbOptions> mongoDbOptions) : base(database, mongoDbOptions)
        {
            collection = MongoCollections.TruthOrDare;
        }

        public async Task CreateCard(TodBson todBson)
        {
            try
            {
                await Items.InsertOneAsync(todBson);
            }
            catch (InvalidOperationException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<TodBson>> GetAllCards()
        {
            try
            {
                return await Items.Find(Builders<TodBson>.Filter.Empty).ToListAsync();
            }
            catch (InvalidOperationException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TodBson> GetCard(Guid guid)
        {
            try
            {
                return await Items.Find(Builders<TodBson>.Filter.Eq(x => x.CardId, guid)).FirstAsync();
            }
            catch (InvalidOperationException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TodBson> DeleteCard(Guid guid)
        {
            try
            {
                var result = await Items.Find(Builders<TodBson>.Filter.Eq(x => x.CardId, guid)).FirstAsync();
                await Items.FindOneAndDeleteAsync(Builders<TodBson>.Filter.Eq(x => x.CardId, guid));

                return result;
            }
            catch (InvalidOperationException ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
using Domain.CardGamesGuruMiniApp.Configuration;
using Infrastructure.CardGamesGuruMiniApp.Models.TotModels;
using Infrastructure.CardGamesGuruMiniApp.Repositories.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Infrastructure.CardGamesGuruMiniApp.Repositories
{
    public class TotRepository : BaseRepository<TotBson>, ITotRepository
    {
        public TotRepository(IMongoDatabase database, IOptions<MongoDbOptions> mongoDbOptions) : base(database, mongoDbOptions)
        {
            collection = MongoCollections.ThisOrThat;
        }

        public async Task CreateCard(TotBson totBson)
        {
            try
            {
                await Items.InsertOneAsync(totBson);
            }
            catch (InvalidOperationException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TotBson> DeleteCard(Guid guid)
        {
            try
            {
                var result = await Items.Find(Builders<TotBson>.Filter.Eq(x => x.CardId, guid)).FirstAsync();
                await Items.DeleteOneAsync(Builders<TotBson>.Filter.Eq(x => x.CardId, guid));

                return result;
            }
            catch (InvalidOperationException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<TotBson>> GetAllCards()
        {
            try
            {
                return await Items.Find(Builders<TotBson>.Filter.Empty).ToListAsync();
            }
            catch (InvalidOperationException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TotBson> GetCard(Guid guid)
        {
            try
            {
                return await Items.Find(Builders<TotBson>.Filter.Eq(x => x.CardId, guid)).FirstAsync();
            }
            catch (InvalidOperationException ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
using Domain.CardGamesGuruMiniApp.Configuration;
using Infrastructure.CardGamesGuruMiniApp.Models.GamesModels;
using Infrastructure.CardGamesGuruMiniApp.Models.TotModels;
using Infrastructure.CardGamesGuruMiniApp.Repositories.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

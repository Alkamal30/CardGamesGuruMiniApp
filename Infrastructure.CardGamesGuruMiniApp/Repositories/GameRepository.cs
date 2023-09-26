using Domain.CardGamesGuruMiniApp.Configuration;
using Domain.CardGamesGuruMiniApp.Entities.Game.GameEntities;
using Infrastructure.CardGamesGuruMiniApp.Models.GamesModels;
using Infrastructure.CardGamesGuruMiniApp.Repositories.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Infrastructure.CardGamesGuruMiniApp.Repositories
{
    public class GameRepository : BaseRepository<GameBson>, IGameRepository
    {
        public GameRepository(IMongoDatabase database,IOptions<MongoDbOptions> mongoDbOptions) : base(database, mongoDbOptions)
        {
            collection = MongoCollections.Games;
        }

        public async Task CreateGame(GameBson game)
        {
            try
            {
                await Items.InsertOneAsync(game);
            }
            catch(InvalidOperationException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<GameBson> GetGameById(string id)
        {
            try
            {
                return await Items.Find(Builders<GameBson>.Filter.Eq(x => x.Id, id)).FirstAsync();
            }
            catch (InvalidOperationException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<GameBson>> GetGames()
        {
            try
            {
                return await Items.Find(Builders<GameBson>.Filter.Empty).ToListAsync();
            }
            catch(InvalidOperationException ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}

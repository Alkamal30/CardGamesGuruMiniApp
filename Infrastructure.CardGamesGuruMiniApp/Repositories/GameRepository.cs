using Domain.CardGamesGuruMiniApp.Configuration;
using Infrastructure.CardGamesGuruMiniApp.Models.GamesModels;
using Infrastructure.CardGamesGuruMiniApp.Models.TodModels;
using Infrastructure.CardGamesGuruMiniApp.Repositories.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;

namespace Infrastructure.CardGamesGuruMiniApp.Repositories
{
    public class GameRepository : BaseRepository<GameBson>, IGameRepository
    {
        public GameRepository(IMongoDatabase database, IOptions<MongoDbOptions> mongoDbOptions) : base(database, mongoDbOptions)
        {
            collection = MongoCollections.Games;
        }

        public async Task CreateGame(GameBson game)
        {
            try
            {
                await Items.InsertOneAsync(game);
            }
            catch (InvalidOperationException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<GameBson> GetGameByNameIndex(string nameIndex)
        {
            try
            {
                return await Items.Find(Builders<GameBson>.Filter.Eq(x => x.NameIndex, nameIndex)).FirstAsync();
            }
            catch (InvalidOperationException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<GameBson> DeleteByNameIndex(string nameIndex)
        {
            try
            {
                var result = await Items.Find(Builders<GameBson>.Filter.Eq(x => x.NameIndex, nameIndex)).FirstAsync();
                await Items.FindOneAndDeleteAsync(Builders<GameBson>.Filter.Eq(x => x.NameIndex, nameIndex));

                return result;
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
            catch (InvalidOperationException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateGame(GameBson game)
        {
            try
            {
                var filter = Builders<GameBson>.Filter.Eq(x => x.NameIndex, game.NameIndex);

                var update = Builders<GameBson>.Update
                    .Set(x => x.NameIndex, game.NameIndex)
                    .Set(x => x.Name, game.Name)
                    .Set(x => x.Description, game.Description)
                    .Set(x => x.UpdatedDate, game.UpdatedDate)
                    .Set(x => x.GameType, game.GameType)
                    .Set(x => x.Colors, game.Colors)
                    .Set(x => x.Endpoint, game.Endpoint);

                await Items.UpdateOneAsync(filter, update);
            }
            catch (InvalidOperationException ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
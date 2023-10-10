using Infrastructure.CardGamesGuruMiniApp.Models.GamesModels;

namespace Infrastructure.CardGamesGuruMiniApp.Repositories.Interfaces
{
    public interface IGameRepository
    {
        Task<List<GameBson>> GetGames();

        Task<GameBson> GetGameByNameIndex(string nameIndex);

        Task<GameBson> DeleteByNameIndex(string nameIndex);

        Task CreateGame(GameBson game);

        Task UpdateGame(GameBson game);
    }
}
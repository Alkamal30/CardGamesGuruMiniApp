using Infrastructure.CardGamesGuruMiniApp.Models.GamesModels;
namespace Infrastructure.CardGamesGuruMiniApp.Repositories.Interfaces
{
    public interface IGameRepository
    {
        Task<List<GameBson>> GetGames();
        Task<GameBson> GetGameById(string id);
        Task CreateGame(GameBson game);
    }
}

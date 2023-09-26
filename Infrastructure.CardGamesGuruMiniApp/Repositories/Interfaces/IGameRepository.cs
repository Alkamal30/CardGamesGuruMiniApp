using Infrastructure.CardGamesGuruMiniApp.Models.GamesModels;
namespace Infrastructure.CardGamesGuruMiniApp.Repositories.Interfaces
{
    public interface IGameRepository
    {
        Task<List<GameBson>> GetGames();
        Task CreateGame(GameBson game);
    }
}

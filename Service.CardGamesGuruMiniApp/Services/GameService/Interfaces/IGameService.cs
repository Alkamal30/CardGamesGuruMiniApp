using Domain.CardGamesGuruMiniApp.Entities.Game.GameEntities;

namespace Services.CardGamesGuruMiniApp.Services.GameService.Interfaces;

public interface IGameService
{
    public Task<Game> GetGameByIdAsync(string id);
    public Task<List<Game>> GetGamesAsync();
    public Task CreateGameAsync(Game game);

}
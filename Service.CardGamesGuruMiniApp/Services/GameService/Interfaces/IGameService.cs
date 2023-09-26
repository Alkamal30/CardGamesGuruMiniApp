using Domain.CardGamesGuruMiniApp.Entities.Game.GameEntities;

namespace Services.CardGamesGuruMiniApp.Services.GameService.Interfaces;

public interface IGameService
{
    public Task<Game> GetGameByIdAsync(string id);
    public Task<Game> GetGameByNameIndexAsync(string nameIndex);
    public Task<List<Game>> GetGamesAsync();
    public Task CreateGameAsync(Game game);
    public Task<Game> UpdateGameAsync(Game game);

}
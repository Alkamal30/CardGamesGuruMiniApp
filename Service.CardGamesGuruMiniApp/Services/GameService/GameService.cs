using Domain.CardGamesGuruMiniApp.Entities.Game.GameEntities;
using Services.CardGamesGuruMiniApp.Services.GameService.Interfaces;

namespace Services.CardGamesGuruMiniApp.Services.GameService;

public class GameService : IGameService
{
    public async Task<Game> GetGameByIdAsync(int id)
    {
        return new Game()
        {
            Id = Guid.NewGuid(),
            Name = "ID = " + id
        };
    }

    public async Task<List<Game>> GetGamesAsync()
    {
        var result = new List<Game>()
        {
            new Game()
            {
                Id = Guid.NewGuid(),
                Name = "Vladick"
            }
        };

        return result;
    }
}
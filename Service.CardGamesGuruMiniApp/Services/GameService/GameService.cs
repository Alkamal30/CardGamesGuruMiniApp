using Domain.CardGamesGuruMiniApp.Entities.Game.GameEntities;
using Services.CardGamesGuruMiniApp.Services.GameService.Interfaces;
using Infrastructure.CardGamesGuruMiniApp.Repositories.Interfaces;
using Infrastructure.CardGamesGuruMiniApp.Models.GamesModels;
using MongoDB.Bson;
using AutoMapper;

namespace Services.CardGamesGuruMiniApp.Services.GameService;

public class GameService : IGameService
{
    private readonly IGameRepository gameRepository;
    private readonly IMapper mapper;
    public GameService(IGameRepository gameRepository, IMapper mapper)
    {
        this.gameRepository = gameRepository;
        this.mapper = mapper;
    }

    public async Task CreateGameAsync(Game game)
    {
        var item = new GameBson()
        {
            Name = game.Name,
            Description = game.Description,
            NameIndex = game.NameIndex,
            CreatedDate = game.CreatedDate,
            GameType = game.GameType,
        };
        item.Id = game.Id.ToString();

        //item = mapper.Map<GameBson>(game);
        

        await gameRepository.CreateGame(item);

    }

    public async Task<Game> GetGameByIdAsync(string id)
    {
        var result = new Game();

        var game = await gameRepository.GetGameById(id);
        if (game == null) return result;

        result.Name = game.Name;
        result.Description = game.Description;
        result.NameIndex = game.NameIndex;
        result.CreatedDate = game.CreatedDate;
        result.UpdatedDate = game.UpdatedDate;
        result.Id = new Guid(game.Id);
        result.GameType = game.GameType;

        return result;
    }


    public async Task<List<Game>> GetGamesAsync()
    {
        var result = new List<Game>();

        var gamesList = await gameRepository.GetGames();
        if (gamesList == null) return result;

        foreach (var item in gamesList)
        {
            result.Add(new Game
            {
                Id = new Guid(item.Id),
                Name = item.Name,
                GameType = item.GameType,
                CreatedDate = item.CreatedDate,
                NameIndex=item.NameIndex,
                Description = item.Description,
                UpdatedDate = item.UpdatedDate
            });
        }

        return result;
    }
}
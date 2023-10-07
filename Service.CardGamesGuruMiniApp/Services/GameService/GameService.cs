using AutoMapper;
using Domain.CardGamesGuruMiniApp.Entities.Game.GameEntities;
using Infrastructure.CardGamesGuruMiniApp.Models.GamesModels;
using Infrastructure.CardGamesGuruMiniApp.Repositories.Interfaces;
using Services.CardGamesGuruMiniApp.Services.GameService.Interfaces;
using Services.CardGamesGuruMiniApp.Validations;

namespace Services.CardGamesGuruMiniApp.Services.GameService;

public class GameService : IGameService
{
    private readonly IGameRepository _gameRepository;
    private readonly IMapper _mapper;

    public GameService(IGameRepository gameRepository, IMapper mapper)
    {
        _gameRepository = gameRepository;
        _mapper = mapper;
    }

    public async Task CreateGameAsync(Game game)
    {
        if (!game.IsGameValid()) throw new Exception("Not valid game object");
        var gameBson = _mapper.Map<GameBson>(game);

        await _gameRepository.CreateGame(gameBson);
    }

    public async Task<Game> DeleteGameByNameIndexAsync(string nameIndex)
    {
        var result = new Game();

        var game = await _gameRepository.DeleteByNameIndex(nameIndex);
        if (game == null) return result;

        result = _mapper.Map<Game>(game);

        return result;
    }

    public async Task<Game> GetGameByNameIndexAsync(string nameIndex)
    {
        var result = new Game();

        var game = await _gameRepository.GetGameByNameIndex(nameIndex);
        if (game == null) return result;

        result = _mapper.Map<Game>(game);

        return result;
    }

    public async Task<List<Game>> GetGamesAsync()
    {
        var result = new List<Game>();

        var gamesList = await _gameRepository.GetGames();
        if (gamesList == null) return result;

        foreach (var item in gamesList)
        {
            var game = new Game();
            result.Add(_mapper.Map<Game>(item));
        }

        return result;
    }

    public async Task UpdateGameAsync(Game game)
    {
        if (!game.IsGameValid()) throw new Exception("Not valid game object");

        var gameBson = _mapper.Map<GameBson>(game);

        await _gameRepository.UpdateGame(gameBson);
    }
}
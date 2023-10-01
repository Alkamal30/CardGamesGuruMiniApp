using Domain.CardGamesGuruMiniApp.Entities.Game.GameEntities;
using MediatR;
using Services.CardGamesGuruMiniApp.Services.GameService.Interfaces;

namespace Services.CardGamesGuruMiniApp.Handlers.GameHandler;

public class GetGamesInformationCommand : IRequest<IList<Game>>
{
}

public class GetGamesInformationHandler : IRequestHandler<GetGamesInformationCommand, IList<Game>>
{
    private readonly IGameService _gameService;

    public GetGamesInformationHandler(IGameService gameService)
    {
        _gameService = gameService;
    }

    public async Task<IList<Game>> Handle(GetGamesInformationCommand request, CancellationToken cancellationToken)
    {
        var result = new List<Game>();

        result = await _gameService.GetGamesAsync();

        return result;
    }
}
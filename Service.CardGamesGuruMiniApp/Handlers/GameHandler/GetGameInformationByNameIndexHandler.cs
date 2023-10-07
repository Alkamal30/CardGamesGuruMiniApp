using Domain.CardGamesGuruMiniApp.Entities.Game.GameEntities;
using MediatR;
using Services.CardGamesGuruMiniApp.Services.GameService.Interfaces;

namespace Services.CardGamesGuruMiniApp.Handlers.GameHandler;

public class GetGameInformationByNameIndexQuery : IRequest<Game>
{
    public string NameIndex { get; set; }
}

public class GetGameInformationByNameIndexHandler : IRequestHandler<GetGameInformationByNameIndexQuery, Game>
{
    private readonly IGameService gameService;

    public GetGameInformationByNameIndexHandler(IGameService gameService)
    {
        this.gameService = gameService;
    }

    public async Task<Game> Handle(GetGameInformationByNameIndexQuery request, CancellationToken cancellationToken)
    {
        var result = await gameService.GetGameByNameIndexAsync(request.NameIndex);

        return result;
    }
}
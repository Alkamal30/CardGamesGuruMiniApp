using MediatR;
using Domain.CardGamesGuruMiniApp.Entities.TotEntities;
using Services.CardGamesGuruMiniApp.Services.TotService.Interfaces;
using Services.CardGamesGuruMiniApp.Services.GameService;

namespace Services.CardGamesGuruMiniApp.Handlers.GameHandler;

public class GetAllCardsQuery : IRequest<List<TotCard>>
{
}

public class GetAllCardsHandler : IRequestHandler<GetAllCardsQuery, List<TotCard>>
{

    private readonly ITotService _totService;

    public GetAllCardsHandler(ITotService totService)
    {
        _totService = totService;
    }

    public async Task<List<TotCard>> Handle(GetAllCardsQuery request, CancellationToken cancellationToken)
    { 

        var result = await _totService.GetAllTotCardsAsync();

        return result;
    }
}
using MediatR;
using Domain.CardGamesGuruMiniApp.Entities.TotEntities;
using Services.CardGamesGuruMiniApp.Services.TotService.Interfaces;
using Services.CardGamesGuruMiniApp.Services.GameService;

namespace Services.CardGamesGuruMiniApp.Handlers.GameHandler;

public class GetCardRandomQuery : IRequest<TotCard>
{
   public string CardId { get; set; }
}

public class GetCardRandomHandler : IRequestHandler<GetCardRandomQuery, TotCard>
{

    private readonly ITotService _totService;

    public GetCardRandomHandler(ITotService totService)
    {
        _totService = totService;
    }

    public async Task<TotCard> Handle(GetCardRandomQuery request, CancellationToken cancellationToken)
    {
        var guid = String.IsNullOrEmpty(request.CardId) ?
            Guid.NewGuid() : 
            new Guid(request.CardId);

        var result = await _totService.GetTotCardAsync(guid);

        return result;
    }
}
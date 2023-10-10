using Domain.CardGamesGuruMiniApp.Entities.TotEntities;
using MediatR;
using Services.CardGamesGuruMiniApp.Services.TotService.Interfaces;

namespace Services.CardGamesGuruMiniApp.Handlers.GameHandler;

public class GetCardByIdQuery : IRequest<TotCard>
{
    public string CardId { get; set; }
}

public class GetCardByIdHandler : IRequestHandler<GetCardByIdQuery, TotCard>
{
    private readonly ITotService _totService;

    public GetCardByIdHandler(ITotService totService)
    {
        _totService = totService;
    }

    public async Task<TotCard> Handle(GetCardByIdQuery request, CancellationToken cancellationToken)
    {
        var guid = String.IsNullOrEmpty(request.CardId) ?
            Guid.NewGuid() :
            new Guid(request.CardId);

        var result = await _totService.GetTotCardAsync(guid);

        return result;
    }
}
using Domain.CardGamesGuruMiniApp.Entities.TodEntities;
using MediatR;
using Services.CardGamesGuruMiniApp.Services.TodService.Interfaces;

namespace Services.CardGamesGuruMiniApp.Handlers.TodHandler;

public class GetToDCardByIdQuery : IRequest<TodCard>
{
    public string CardId { get; set; }
}

public class GetToDCardByIdHandler : IRequestHandler<GetToDCardByIdQuery, TodCard>
{
    private readonly ITodService _todService;

    public GetToDCardByIdHandler(ITodService todService)
    {
        _todService = todService;
    }

    public async Task<TodCard> Handle(GetToDCardByIdQuery request, CancellationToken cancellationToken)
    {
        var guid = String.IsNullOrEmpty(request.CardId) ?
            Guid.NewGuid() :
            new Guid(request.CardId);

        var result = await _todService.GetTodCardAsync(guid);

        return result;
    }
}
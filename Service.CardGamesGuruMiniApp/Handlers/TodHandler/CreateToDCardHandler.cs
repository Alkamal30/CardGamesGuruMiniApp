using Domain.CardGamesGuruMiniApp.Entities.TodEntities;
using MediatR;
using Services.CardGamesGuruMiniApp.Services.TodService.Interfaces;

namespace Services.CardGamesGuruMiniApp.Handlers.TodHandler;

public class CreateToDCardQuery : IRequest<TodCard>
{
    public string Truth { get; set; }
    public string Dare { get; set; }
}

public class CreateToDCardHandler : IRequestHandler<CreateToDCardQuery, TodCard>
{
    private readonly ITodService _todService;

    public CreateToDCardHandler(ITodService todService)
    {
        _todService = todService;
    }

    public async Task<TodCard> Handle(CreateToDCardQuery request, CancellationToken cancellationToken)
    {
        var card = new TodCard()
        {
            Truth = request.Truth,
            Dare = request.Dare,
            CardId = Guid.NewGuid(),
            CreatedDate = DateTime.UtcNow
        };

        await _todService.CreateTodCardAsync(card);

        return card;
    }
}
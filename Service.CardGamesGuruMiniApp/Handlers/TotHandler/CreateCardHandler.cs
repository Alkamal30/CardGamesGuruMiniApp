using MediatR;
using Domain.CardGamesGuruMiniApp.Entities.TotEntities;
using Services.CardGamesGuruMiniApp.Services.TotService.Interfaces;

namespace Services.CardGamesGuruMiniApp.Handlers.GameHandler;

public class CreateCardQuery : IRequest
{
    public string FirstQueston { get; set; }
    public string SecondQueston { get; set; }
}

public class CreateCardHandler : IRequestHandler<CreateCardQuery>
{

    private readonly ITotService _totService;

    public CreateCardHandler(ITotService totService)
    {
        _totService = totService;
    }

    public async Task Handle(CreateCardQuery request, CancellationToken cancellationToken)
    {
        var card = new TotCard()
        {
            FirstQuestion = request.FirstQueston,
            SecondQuestion = request.SecondQueston,
            CardId = Guid.NewGuid(),
            CreatedDate = DateTime.UtcNow
        };

        await _totService.CreateTotCardAsync(card);

    }
}
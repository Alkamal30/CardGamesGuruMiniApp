using Domain.CardGamesGuruMiniApp.Entities.TotEntities;
using MediatR;
using Services.CardGamesGuruMiniApp.Services.TotService.Interfaces;

namespace Services.CardGamesGuruMiniApp.Handlers.TotHandler
{
    public class GetRandomCardQuery : IRequest<TotCard>
    {
    }

    public class GetRandomCardHandler : IRequestHandler<GetRandomCardQuery, TotCard>
    {
        private readonly ITotService _totService;

        public GetRandomCardHandler(ITotService totService)
        {
            _totService = totService;
        }

        public async Task<TotCard> Handle(GetRandomCardQuery request, CancellationToken cancellationToken)
        {
            return await _totService.GetRandomTotCardAsync();
        }
    }
}
using Domain.CardGamesGuruMiniApp.Entities.TodEntities;
using MediatR;
using Services.CardGamesGuruMiniApp.Services.TodService.Interfaces;

namespace Services.CardGamesGuruMiniApp.Handlers.TodHandler
{
    public class GetRandomToDCardQuery : IRequest<TodCard>
    {
    }

    public class GetRandomToDCardHandler : IRequestHandler<GetRandomToDCardQuery, TodCard>
    {
        private readonly ITodService _todService;

        public GetRandomToDCardHandler(ITodService todService)
        {
            _todService = todService;
        }

        public async Task<TodCard> Handle(GetRandomToDCardQuery request, CancellationToken cancellationToken)
        {
            return await _todService.GetRandomTodCardAsync();
        }
    }
}
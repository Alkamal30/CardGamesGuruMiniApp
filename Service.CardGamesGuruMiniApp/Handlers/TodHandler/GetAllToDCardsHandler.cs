using Domain.CardGamesGuruMiniApp.Entities.TodEntities;
using MediatR;
using Services.CardGamesGuruMiniApp.Services.TodService.Interfaces;

namespace Services.CardGamesGuruMiniApp.Handlers.TodHandler
{
    public class GetAllToDCardsQuery : IRequest<List<TodCard>>
    {
    }

    public class GetAllToDCardsHandler : IRequestHandler<GetAllToDCardsQuery, List<TodCard>>
    {
        private readonly ITodService _todService;

        public GetAllToDCardsHandler(ITodService todService)
        {
            _todService = todService;
        }

        public async Task<List<TodCard>> Handle(GetAllToDCardsQuery request, CancellationToken cancellationToken)
        {
            var result = await _todService.GetAllTodCardsAsync();

            return result;
        }
    }
}
using Domain.CardGamesGuruMiniApp.Entities.TodEntities;
using MediatR;
using Services.CardGamesGuruMiniApp.Services.TodService.Interfaces;

namespace Services.CardGamesGuruMiniApp.Handlers.TodHandler
{
    public class DeleteToDCardQuery : IRequest<TodCard>
    {
        public string CardId { get; set; }
    }

    public class DeleteToDCardHandler : IRequestHandler<DeleteToDCardQuery, TodCard>
    {
        private readonly ITodService _todService;

        public DeleteToDCardHandler(ITodService todService)
        {
            _todService = todService;
        }

        public async Task<TodCard> Handle(DeleteToDCardQuery request, CancellationToken cancellationToken)
        {
            var guid = String.IsNullOrEmpty(request.CardId) ?
            Guid.NewGuid() :
            new Guid(request.CardId);

            var result = await _todService.DeleteTodCardAsync(guid);

            return result;
        }
    }
}
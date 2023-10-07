using Domain.CardGamesGuruMiniApp.Entities.TotEntities;
using MediatR;
using Services.CardGamesGuruMiniApp.Services.TotService.Interfaces;

namespace Services.CardGamesGuruMiniApp.Handlers.TotHandler
{
    public class DeleteCardQuery : IRequest<TotCard>
    {
        public string CardId { get; set; }
    }

    public class DeleteCardHandler : IRequestHandler<DeleteCardQuery, TotCard>
    {
        private readonly ITotService _totService;

        public DeleteCardHandler(ITotService totService)
        {
            _totService = totService;
        }

        public async Task<TotCard> Handle(DeleteCardQuery request, CancellationToken cancellationToken)
        {
            var guid = String.IsNullOrEmpty(request.CardId) ?
            Guid.NewGuid() :
            new Guid(request.CardId);

            var result = await _totService.DeleteTotCardAsync(guid);

            return result;
        }
    }
}

using Domain.CardGamesGuruMiniApp.Entities.TotEntities;

namespace Services.CardGamesGuruMiniApp.Services.TotService.Interfaces
{
    public interface ITotService
    {
        public Task<TotCard> GetTotCardAsync(Guid guid);
        public Task CreateTotCardAsync(TotCard totCard);
    }
}

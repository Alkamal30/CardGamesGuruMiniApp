using Domain.CardGamesGuruMiniApp.Entities.TotEntities;

namespace Services.CardGamesGuruMiniApp.Services.TotService.Interfaces
{
    public interface ITotService
    {
        public Task<TotCard> GetTotCardAsync(Guid guid);

        public Task<TotCard> GetRandomTotCardAsync();

        public Task<TotCard> DeleteTotCardAsync(Guid guid);

        public Task<List<TotCard>> GetAllTotCardsAsync();

        public Task CreateTotCardAsync(TotCard totCard);
    }
}
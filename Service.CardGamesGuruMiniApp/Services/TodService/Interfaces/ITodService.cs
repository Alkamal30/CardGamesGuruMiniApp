using Domain.CardGamesGuruMiniApp.Entities.TodEntities;

namespace Services.CardGamesGuruMiniApp.Services.TodService.Interfaces
{
    public interface ITodService
    {
        public Task<TodCard> GetTodCardAsync(Guid guid);

        public Task<TodCard> GetRandomTodCardAsync();

        public Task<List<TodCard>> GetAllTodCardsAsync();

        public Task CreateTodCardAsync(TodCard todCard);

        public Task<TodCard> DeleteTodCardAsync(Guid guid);
    }
}
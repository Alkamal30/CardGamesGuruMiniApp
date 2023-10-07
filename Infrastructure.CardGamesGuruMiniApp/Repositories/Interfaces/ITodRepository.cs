using Infrastructure.CardGamesGuruMiniApp.Models.TodModels;

namespace Infrastructure.CardGamesGuruMiniApp.Repositories.Interfaces
{
    public interface ITodRepository
    {
        public Task<TodBson> GetCard(Guid guid);

        public Task<List<TodBson>> GetAllCards();

        public Task CreateCard(TodBson todBson);

        public Task<TodBson> DeleteCard(Guid guid);
    }
}
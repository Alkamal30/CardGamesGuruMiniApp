using Infrastructure.CardGamesGuruMiniApp.Models.TotModels;

namespace Infrastructure.CardGamesGuruMiniApp.Repositories.Interfaces
{
    public interface ITotRepository
    {
        public Task<TotBson> GetCard(Guid guid);

        public Task<List<TotBson>> GetAllCards();

        public Task CreateCard(TotBson totBson);

        public Task<TotBson> DeleteCard(Guid guid);
    }
}
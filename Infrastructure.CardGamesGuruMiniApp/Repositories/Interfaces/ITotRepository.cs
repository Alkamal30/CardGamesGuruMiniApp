using Infrastructure.CardGamesGuruMiniApp.Models.GamesModels;
using Infrastructure.CardGamesGuruMiniApp.Models.TotModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.CardGamesGuruMiniApp.Repositories.Interfaces
{
    public interface ITotRepository
    {
        public Task<TotBson> GetCard(Guid guid);
        public Task<TotBson> GetRandomCard();
        public Task<List<TotBson>> GetAllCards();
        public Task CreateCard(TotBson totBson);
    }
}

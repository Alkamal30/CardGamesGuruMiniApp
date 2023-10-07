using AutoMapper;
using Domain.CardGamesGuruMiniApp.Entities.TotEntities;
using Infrastructure.CardGamesGuruMiniApp.Models.TotModels;
using Infrastructure.CardGamesGuruMiniApp.Repositories.Interfaces;
using Services.CardGamesGuruMiniApp.Services.TotService.Interfaces;

namespace Services.CardGamesGuruMiniApp.Services.TotService
{
    public class TotService : ITotService
    {
        private ITotRepository _totRepository;
        private readonly IMapper _mapper;

        private List<TotBson> _usedCards;

        public TotService(ITotRepository totRepository, IMapper mapper)
        {
            _totRepository = totRepository;
            _mapper = mapper;

            _usedCards = new List<TotBson>();
        }

        public async Task CreateTotCardAsync(TotCard totCard)
        {
            var cardBson = new TotBson();

            cardBson = _mapper.Map<TotBson>(totCard);

            await _totRepository.CreateCard(cardBson);
        }

        public async Task<List<TotCard>> GetAllTotCardsAsync()
        {
            var listBson = await _totRepository.GetAllCards();

            var result = listBson
                .Select(x => _mapper.Map<TotCard>(x))
                .ToList();

            return result;
        }

        public async Task<TotCard> GetRandomTotCardAsync()
        {
            var listBson = await _totRepository.GetAllCards();

            Random random = new Random();

            var cardBson = listBson.OrderBy(x => random.Next()).FirstOrDefault();

            var card = _mapper.Map<TotCard>(cardBson);

            return card;
        }

        public async Task<TotCard> GetTotCardAsync(Guid guid)
        {
            var result = await _totRepository.GetCard(guid);

            var card = _mapper.Map<TotCard>(result);

            return card;
        }

        public async Task<TotCard> DeleteTotCardAsync(Guid guid)
        {
            var result = await _totRepository.DeleteCard(guid);

            var card = _mapper.Map<TotCard>(result);

            return card;
        }
    }
}
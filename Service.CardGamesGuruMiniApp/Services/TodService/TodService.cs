using AutoMapper;
using Domain.CardGamesGuruMiniApp.Entities.TodEntities;
using Infrastructure.CardGamesGuruMiniApp.Models.TodModels;
using Infrastructure.CardGamesGuruMiniApp.Repositories.Interfaces;
using Services.CardGamesGuruMiniApp.Services.TodService.Interfaces;

namespace Services.CardGamesGuruMiniApp.Services.TodService
{
    public class TodService : ITodService
    {
        private ITodRepository _todRepository;
        private readonly IMapper _mapper;

        private List<TodBson> _usedCards;

        public TodService(ITodRepository todRepository, IMapper mapper)
        {
            _todRepository = todRepository;
            _mapper = mapper;

            _usedCards = new List<TodBson>();
        }

        public async Task CreateTodCardAsync(TodCard todCard)
        {
            var cardBson = new TodBson();

            cardBson = _mapper.Map<TodBson>(todCard);

            await _todRepository.CreateCard(cardBson);
        }

        public async Task<List<TodCard>> GetAllTodCardsAsync()
        {
            var listBson = await _todRepository.GetAllCards();

            var result = listBson
                .Select(x => _mapper.Map<TodCard>(x))
                .ToList();

            return result;
        }

        public async Task<TodCard> GetRandomTodCardAsync()
        {
            var listBson = await _todRepository.GetAllCards();

            Random random = new Random();

            var totalList = listBson.Except(_usedCards);

            var cardBson = totalList.OrderBy(x => random.Next()).FirstOrDefault();

            _usedCards.Add(cardBson);

            var card = _mapper.Map<TodCard>(cardBson);

            return card;
        }

        public async Task<TodCard> GetTodCardAsync(Guid guid)
        {
            var result = await _todRepository.GetCard(guid);

            var card = _mapper.Map<TodCard>(result);

            return card;
        }

        public async Task<TodCard> DeleteTodCardAsync(Guid guid)
        {
            var result = await _todRepository.DeleteCard(guid);

            var card = _mapper.Map<TodCard>(result);

            return card;
        }
    }
}
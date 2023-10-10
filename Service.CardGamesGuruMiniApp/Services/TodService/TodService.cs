using AutoMapper;
using Domain.CardGamesGuruMiniApp.Entities.TodEntities;
using Domain.CardGamesGuruMiniApp.Entities.TotEntities;
using Infrastructure.CardGamesGuruMiniApp.Models.TodModels;
using Infrastructure.CardGamesGuruMiniApp.Repositories.Interfaces;
using Services.CardGamesGuruMiniApp.Extensions;
using Services.CardGamesGuruMiniApp.Services.TodService.Interfaces;
using System.Collections.Concurrent;

namespace Services.CardGamesGuruMiniApp.Services.TodService
{
    public class TodService : ITodService
    {
        private static ConcurrentQueue<TodCard> _uniqueCardsQueue;

        private ITodRepository _todRepository;
        private readonly IMapper _mapper;


        static TodService() {
            _uniqueCardsQueue = new ConcurrentQueue<TodCard>();
        }

        public TodService(ITodRepository todRepository, IMapper mapper)
        {
            _todRepository = todRepository;
            _mapper = mapper;
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
            if(_uniqueCardsQueue.Count == 0) 
            {
                await FillUniqueCardsQueue();
            }

            _uniqueCardsQueue.TryDequeue(out var card); 
            
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


        private async Task FillUniqueCardsQueue() 
        {
            List<TodCard> allCardsList = await GetAllTodCardsAsync();
            allCardsList.Shuffle();

            foreach(TodCard card in allCardsList) 
            {
                _uniqueCardsQueue.Enqueue(card);
            }
        }
    }
}
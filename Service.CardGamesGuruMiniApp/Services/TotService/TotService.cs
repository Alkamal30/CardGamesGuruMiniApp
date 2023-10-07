using AutoMapper;
using Domain.CardGamesGuruMiniApp.Entities.TotEntities;
using Infrastructure.CardGamesGuruMiniApp.Models.TotModels;
using Infrastructure.CardGamesGuruMiniApp.Repositories.Interfaces;
using Services.CardGamesGuruMiniApp.Extensions;
using Services.CardGamesGuruMiniApp.Services.TotService.Interfaces;
using System.Collections.Concurrent;

namespace Services.CardGamesGuruMiniApp.Services.TotService
{
    public class TotService : ITotService
    {
        private static ConcurrentQueue<TotCard> _uniqueCardsQueue;

        private ITotRepository _totRepository;
        private readonly IMapper _mapper;


        static TotService() 
        {
            _uniqueCardsQueue = new ConcurrentQueue<TotCard>();
        }

        public TotService(ITotRepository totRepository, IMapper mapper)
        {
            _totRepository = totRepository;
            _mapper = mapper;
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
            if(_uniqueCardsQueue.Count == 0) 
            {
                await FillUniqueCardsQueue();
            }

            _uniqueCardsQueue.TryDequeue(out TotCard card);

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


        private async Task FillUniqueCardsQueue() 
        {
            List<TotCard> allCardsList = await GetAllTotCardsAsync();
            allCardsList.Shuffle();

            foreach(TotCard card in allCardsList) 
            {
                _uniqueCardsQueue.Enqueue(card);
            }
        }
    }
}
﻿using Domain.CardGamesGuruMiniApp.Entities.TotEntities;
using Infrastructure.CardGamesGuruMiniApp.Models.TotModels;
using Infrastructure.CardGamesGuruMiniApp.Repositories.Interfaces;
using Services.CardGamesGuruMiniApp.Services.TotService.Interfaces;
using System;

namespace Services.CardGamesGuruMiniApp.Services.TotService
{
    public class TotService : ITotService
    {
        private ITotRepository _totRepository;
        public TotService(ITotRepository totRepository)
        {
            _totRepository = totRepository;
        }

        public async Task CreateTotCardAsync(TotCard totCard)
        {
            var cardBson = new TotBson();

            cardBson.CreatedDate = totCard.CreatedDate;
            cardBson.CardId = totCard.CardId;
            cardBson.FirstQuestion = totCard.FirstQuestion;
            cardBson.SecondQuestion = totCard.SecondQuestion;

            await _totRepository.CreateCard(cardBson);

        }

        public async Task<List<TotCard>> GetAllTotCardsAsync()
        {
            var listBson = await _totRepository.GetAllCards();

            var result = listBson
                .Select(x => new TotCard()
                {
                    CardId = x.CardId,
                    CreatedDate = x.CreatedDate,
                    UpdatedDate = x.UpdatedDate,
                    FirstQuestion = x.FirstQuestion,
                    SecondQuestion = x.SecondQuestion
                })
                .ToList();

            return result;
        }

        public async Task<TotCard> GetTotCardAsync(Guid guid)
        {
            var result = await _totRepository.GetCard(guid);

            var card = new TotCard()
            {
                FirstQuestion = result.FirstQuestion,
                SecondQuestion = result.SecondQuestion,
                CardId = result.CardId,
                CreatedDate = result.CreatedDate
            };

            return card;
        }
    }
}

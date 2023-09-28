﻿using AutoMapper.Internal.Mappers;
using Domain.CardGamesGuruMiniApp.Entities.Game.GameEntities;
using Domain.CardGamesGuruMiniApp.Enums.GameEnums;
using Domain.CardGamesGuruMiniApp.Mapping;
using MediatR;
using Services.CardGamesGuruMiniApp.Services.GameService.Interfaces;
using System.Text.Json.Serialization;

namespace Services.CardGamesGuruMiniApp.Handlers.GameHandler
{

    public class UpdateGameQuery : IRequest
    {
        public string Name { get; set; }
        public string NameIndex { get; set; }
        public string Description { get; set; }
        public string GameType { get; set; }
    }


    internal class UpdateGameHandler : IRequestHandler<UpdateGameQuery>
    {
        private readonly IGameService gameService;

        public UpdateGameHandler(IGameService gameService)
        {
            this.gameService = gameService;
        }
        public async Task Handle(UpdateGameQuery request, CancellationToken cancellationToken)
        {
            var game = new Game()
            {
                Name = String.IsNullOrEmpty(request.Name) ? String.Empty : request.Name,
                Description = String.IsNullOrEmpty(request.Description) ? String.Empty : request.Description,
                GameType = String.IsNullOrEmpty(request.GameType) ? GameType.NoPlayers : EnumMapping.MapGameType(request.GameType),
                UpdatedDate = DateTime.UtcNow,
                NameIndex = request.NameIndex
            };

            await gameService.UpdateGameAsync(game);
        }
    }
}
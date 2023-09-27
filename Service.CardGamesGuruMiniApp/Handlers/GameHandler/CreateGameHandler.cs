using AutoMapper.Internal.Mappers;
using Domain.CardGamesGuruMiniApp.Entities.Game.GameEntities;
using Domain.CardGamesGuruMiniApp.Enums.GameEnums;
using Domain.CardGamesGuruMiniApp.Mapping;
using MediatR;
using Services.CardGamesGuruMiniApp.Services.GameService.Interfaces;
using System.Text.Json.Serialization;

namespace Services.CardGamesGuruMiniApp.Handlers.GameHandler
{

    public class CreateGameQuery : IRequest
    {
        public string Name { get; set; }
        public string NameIndex { get; set; }
        public string Description { get; set; }
        public string GameType { get; set; }
    }


    internal class CreateGameHandler : IRequestHandler<CreateGameQuery>
    {
        private readonly IGameService gameService;

        public CreateGameHandler(IGameService gameService)
        {
            this.gameService = gameService;
        }
        public async Task Handle(CreateGameQuery request, CancellationToken cancellationToken)
        {
            var game = new Game()
            {
                Name = request.Name,
                Description = request.Description,
                GameType = EnumMapping.MapGameType(request.GameType),
                CreatedDate = DateTime.UtcNow,
                NameIndex = request.NameIndex
            };

            await gameService.CreateGameAsync(game);
        }
    }
}

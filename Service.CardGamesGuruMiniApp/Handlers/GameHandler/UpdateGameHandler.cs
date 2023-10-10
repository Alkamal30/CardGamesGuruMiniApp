using Domain.CardGamesGuruMiniApp.Entities.Game.GameEntities;
using Domain.CardGamesGuruMiniApp.Enums.GameEnums;
using Domain.CardGamesGuruMiniApp.Mapping;
using MediatR;
using Services.CardGamesGuruMiniApp.Services.GameService.Interfaces;

namespace Services.CardGamesGuruMiniApp.Handlers.GameHandler
{
    public class UpdateGameQuery : IRequest
    {
        public string Name { get; set; }
        public string NameIndex { get; set; }
        public string Description { get; set; }
        public string GameType { get; set; }
        public string Endpoint { get; set; }
        public List<string> Colors { get; set; }
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
                GameType = String.IsNullOrEmpty(request.GameType) ? GameType.NoPlayersJustCards : EnumMapping.MapGameType(request.GameType),
                Endpoint = String.IsNullOrEmpty(request.Endpoint) ? String.Empty : request.Endpoint,
                Colors = (request.Colors.Count == 0 || request.Colors == null) ? new List<string>() : request.Colors,
                UpdatedDate = DateTime.UtcNow,
                NameIndex = request.NameIndex
            };

            await gameService.UpdateGameAsync(game);
        }
    }
}
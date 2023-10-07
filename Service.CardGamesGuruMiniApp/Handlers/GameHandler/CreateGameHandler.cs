using Domain.CardGamesGuruMiniApp.Entities.Game.GameEntities;
using Domain.CardGamesGuruMiniApp.Mapping;
using MediatR;
using Services.CardGamesGuruMiniApp.Services.GameService.Interfaces;

namespace Services.CardGamesGuruMiniApp.Handlers.GameHandler
{
    public class CreateGameQuery : IRequest<Game>
    {
        public string Name { get; set; }
        public string NameIndex { get; set; }
        public string Description { get; set; }
        public string GameType { get; set; }
        public string Endpoint { get; set; }
        public List<string> Colors { get; set; }
        public string Font { get; set; }
    }

    internal class CreateGameHandler : IRequestHandler<CreateGameQuery, Game>
    {
        private readonly IGameService gameService;

        public CreateGameHandler(IGameService gameService)
        {
            this.gameService = gameService;
        }

        public async Task<Game> Handle(CreateGameQuery request, CancellationToken cancellationToken)
        {
            var game = new Game()
            {
                Name = request.Name,
                Description = request.Description,
                GameType = EnumMapping.MapGameType(request.GameType),
                CreatedDate = DateTime.UtcNow,
                NameIndex = request.NameIndex,
                Endpoint = request.Endpoint,
                Colors = request.Colors,
                Font = request.Font
            };

            await gameService.CreateGameAsync(game);

            return game;
        }
    }
}
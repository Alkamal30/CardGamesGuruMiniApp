using Domain.CardGamesGuruMiniApp.Entities.Game.GameEntities;
using MediatR;
using Services.CardGamesGuruMiniApp.Services.GameService.Interfaces;

namespace Services.CardGamesGuruMiniApp.Handlers.GameHandler
{
    public class DeleteGameQuery : IRequest<Game>
    {
        public string NameIndex { get; set; }
    }

    public class DeleteGameHandler : IRequestHandler<DeleteGameQuery, Game>
    {
        private readonly IGameService _gameService;

        public DeleteGameHandler(IGameService gameService)
        {
            _gameService = gameService;
        }

        public async Task<Game> Handle(DeleteGameQuery request, CancellationToken cancellationToken)
        {
            var result = await _gameService.DeleteGameByNameIndexAsync(request.NameIndex);

            return result;
        }
    }
}
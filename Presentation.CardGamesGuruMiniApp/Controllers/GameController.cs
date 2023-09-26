using MediatR;
using Microsoft.AspNetCore.Mvc;
using Services.CardGamesGuruMiniApp.Handlers.GameHandler;

namespace WebApp.Controllers;

[Route("api/game")]
[ApiController]
public class GameController : ControllerBase
{
    private readonly IMediator _mediator;

    public GameController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    [Route("gamebyid")]
    public async Task<ActionResult> GetGameInformationById(int id)
    {

        var result = await _mediator.Send(new GetGameInformationByIdQuery()
        {
            Id = id
        });
        
        return Ok(result);
    }

    [HttpGet]
    [Route("games")]
    public async Task<ActionResult> GetAllGames()
    {
        return Ok(await _mediator.Send(new GetGamesInformationCommand()));
    }

    [HttpPost]
    [Route("create")]
    public async Task<ActionResult> CreateNewGame(CreateGameQuery query)
    {
        await _mediator.Send(query);
        return Ok();
    }
}
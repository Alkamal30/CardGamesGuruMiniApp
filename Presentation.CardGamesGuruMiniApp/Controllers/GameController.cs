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
    [Route("gamebyname")]
    public async Task<ActionResult> GetGameInformationByNameIndex(string nameIndex)
    {
        var result = await _mediator.Send(new GetGameInformationByNameIndexQuery()
        {
            NameIndex = nameIndex
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
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpDelete]
    [Route("delete")]
    public async Task<ActionResult> DeleteGame(DeleteGameQuery query)
    {
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    [Route("update")]
    public async Task<ActionResult> UpdateGame(UpdateGameQuery query)
    {
        await _mediator.Send(query);
        return Ok();
    }
}
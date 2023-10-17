using Domain.CardGamesGuruMiniApp.Filters;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.CardGamesGuruMiniApp.Handlers.GameHandler;

namespace WebApp.Controllers;

[Route("api/game")]
[ApiController]
public class GameController : BaseController
{
    public GameController(IMediator mediator) : base(mediator)
    {
       
    }

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
    [ServiceFilter(typeof(ApiKeyAuthFilter))]
    public async Task<ActionResult> CreateNewGame(CreateGameQuery query)
    {
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpDelete]
    [Route("delete")]
    [ServiceFilter(typeof(ApiKeyAuthFilter))]
    public async Task<ActionResult> DeleteGame(DeleteGameQuery query)
    {
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    [Route("update")]
    [ServiceFilter(typeof(ApiKeyAuthFilter))]
    public async Task<ActionResult> UpdateGame(UpdateGameQuery query)
    {
        await _mediator.Send(query);
        return Ok();
    }
}
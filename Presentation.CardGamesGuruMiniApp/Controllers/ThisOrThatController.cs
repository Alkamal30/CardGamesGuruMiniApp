using Domain.CardGamesGuruMiniApp.Entities.TotEntities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Services.CardGamesGuruMiniApp.Handlers.GameHandler;

namespace WebApp.Controllers;

[Route("api/tot")]
[ApiController]
public class ThisOrThatController : ControllerBase
{
    private readonly IMediator _mediator;

    public ThisOrThatController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    [Route("card")]
    public async Task<ActionResult> GetCard([FromBody] GetCardRandomQuery query)
    {

        var result = await _mediator.Send(query);

        return Ok(result);
    }

    [HttpPost]
    [Route("create")]
    public async Task<ActionResult<TotCard>> CreateCard([FromBody] CreateCardQuery query)
    {

        var result = await _mediator.Send(query);

        return Ok(result);
    }
}
using Domain.CardGamesGuruMiniApp.Entities.TotEntities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Services.CardGamesGuruMiniApp.Handlers.GameHandler;
using Services.CardGamesGuruMiniApp.Handlers.TotHandler;

namespace WebApp.Controllers;

[Route("api/tot")]
[ApiController]
public class ThisOrThatController : ControllerBase
{
    private readonly IMediator _mediator;

    public ThisOrThatController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    [Route("card")]
    public async Task<ActionResult> GetCard([FromBody] GetCardByIdQuery query)
    {
        var result = await _mediator.Send(query);

        return Ok(result);
    }

    [HttpDelete]
    [Route("delete")]
    public async Task<ActionResult> DeleteCard([FromBody] DeleteCardQuery query)
    {
        var result = await _mediator.Send(query);

        return Ok(result);
    }

    [HttpGet]
    [Route("cardrandom")]
    public async Task<ActionResult> GetRandomCard()
    {
        var result = await _mediator.Send(new GetRandomCardQuery());

        return Ok(result);
    }

    [HttpGet]
    [Route("allcards")]
    public async Task<ActionResult<List<TotCard>>> GetAllCards()
    {
        var result = await _mediator.Send(new GetAllCardsQuery());

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
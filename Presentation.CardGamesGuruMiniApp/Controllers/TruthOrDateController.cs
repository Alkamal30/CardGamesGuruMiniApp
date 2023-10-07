using Domain.CardGamesGuruMiniApp.Entities.TodEntities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Services.CardGamesGuruMiniApp.Handlers.TodHandler;

namespace WebApp.Controllers;

[Route("api/tod")]
[ApiController]
public class TruthOrDateController : ControllerBase
{
    private readonly IMediator _mediator;

    public TruthOrDateController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    [Route("card")]
    public async Task<ActionResult> GetCard([FromBody] GetToDCardByIdQuery query)
    {
        var result = await _mediator.Send(query);

        return Ok(result);
    }

    [HttpDelete]
    [Route("delete")]
    public async Task<ActionResult> DeleteCard([FromBody] DeleteToDCardQuery query)
    {
        var result = await _mediator.Send(query);

        return Ok(result);
    }

    [HttpGet]
    [Route("cardrandom")]
    public async Task<ActionResult<TodCard>> GetRandomCard()
    {
        var result = await _mediator.Send(new GetRandomToDCardQuery());

        return Ok(result);
    }

    [HttpGet]
    [Route("allcards")]
    public async Task<ActionResult<List<TodCard>>> GetAllCards()
    {
        var result = await _mediator.Send(new GetAllToDCardsQuery());

        return Ok(result);
    }

    [HttpPost]
    [Route("create")]
    public async Task<ActionResult<TodCard>> CreateCard([FromBody] CreateToDCardQuery query)
    {
        var result = await _mediator.Send(query);

        return Ok(result);
    }
}
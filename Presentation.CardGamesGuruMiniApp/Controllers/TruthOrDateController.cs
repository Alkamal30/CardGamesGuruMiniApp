using Domain.CardGamesGuruMiniApp.Entities.TodEntities;
using Domain.CardGamesGuruMiniApp.Filters;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Services.CardGamesGuruMiniApp.Handlers.TodHandler;

namespace WebApp.Controllers;

[Route("api/tod")]
[ApiController]
public class TruthOrDateController : BaseController
{
    public TruthOrDateController(IMediator mediator) : base (mediator)
    {

    }

    [HttpGet]
    [Route("card")]
    public async Task<ActionResult> GetCard([FromBody] GetToDCardByIdQuery query)
    {
        var result = await _mediator.Send(query);

        return Ok(result);
    }

    [HttpDelete]
    [Route("delete")]
    [ServiceFilter(typeof(ApiKeyAuthFilter))]
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
    [ServiceFilter(typeof(ApiKeyAuthFilter))]
    public async Task<ActionResult<TodCard>> CreateCard([FromBody] CreateToDCardQuery query)
    {
        var result = await _mediator.Send(query);

        return Ok(result);
    }
}
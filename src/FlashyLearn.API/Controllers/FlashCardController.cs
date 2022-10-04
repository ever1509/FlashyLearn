using Application.FlashCards.Dtos;
using Application.FlashCards.Queries.RunFlashCards;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FlashyLearn.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FlashCardController : ControllerBase
{
    private readonly IMediator _mediator;

    public FlashCardController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<FlashCardDto>>> GetFlashCards()
    {
        return await _mediator.Send(new RunFlashCards());
    }

}
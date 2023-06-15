using Application.FlashCards.Commands.CreateFlashCard;
using Application.FlashCards.Commands.DeleteFlashCard;
using Application.FlashCards.Dtos;
using Application.FlashCards.Queries.RunFlashCards;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FlashyLearn.API.REST.Controllers;

[ApiController]
[Route("api/v1/flashcards")]
public class FlashCardController : ControllerBase
{
    private readonly IMediator _mediator;

    public FlashCardController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("run-flash-cards")]
    public async Task<ActionResult<List<FlashCardDto>>> RunFlashCards()
    {
        return await _mediator.Send(new RunFlashCards());
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateFlashCard([FromBody] CreateFlashCardCommand command)
    {
        try
        {        
            await _mediator.Send(command);
            return NoContent();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<int>> DeleteFlashCard(string id)
    {
        try
        {        
            await _mediator.Send(new DeleteFlashCard(){Id = id});
            return NoContent();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

}
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FlashyLearn.API.REST.Controllers;

[ApiController]
[Route("api/v1/tags")]
public class TagController : ControllerBase
{
    private readonly IMediator _mediator;

    public TagController(IMediator mediator)
    {
        _mediator = mediator;
    }
}
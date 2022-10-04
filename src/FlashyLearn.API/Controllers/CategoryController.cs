using Application.Categories.Dtos;
using Application.Categories.Queries.AllCategories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FlashyLearn.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly IMediator _mediator;

    public CategoryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<CategoryDto>>> GetCategories()
    {
        return await _mediator.Send(new AllCategories());
    }
}
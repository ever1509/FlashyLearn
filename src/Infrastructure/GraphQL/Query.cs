using Application.Categories.Dtos;
using Application.Categories.Queries.AllCategories;
using Application.FlashCards.Dtos;
using Application.FlashCards.Queries.RunFlashCards;
using Application.Tags.Dtos;
using Application.Tags.Queries.AllTags;
using Domain.Enums;
using MediatR;

namespace Infrastructure.GraphQL;

public class Query
{
    [UseFiltering]
    public async Task<List<CategoryDto>> AllCategories([Service] IMediator mediator, int page = 1, int pageSize = 10, string? userId = null) 
        => await mediator.Send(new AllCategories() {UserId = userId, PageNumber = page, PageSize = pageSize});

    [UseFiltering]
    public async Task<List<TagDto>> AllTags([Service] IMediator mediator, string? flashCardId = null)
        => await mediator.Send(new AllTags() {FlashCardId = flashCardId});

    [UseFiltering]
    public async Task<List<FlashCardDto>> RunFlashCards([Service] IMediator mediator) 
        => await mediator.Send(new RunFlashCards());
    
}
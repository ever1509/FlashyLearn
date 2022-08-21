using Application.Categories.Dtos;
using Application.Categories.Queries.AllCategories;
using Application.FlashCards.Dtos;
using Application.FlashCards.Queries.RunFlashCards;
using Domain.Enums;
using MediatR;

namespace Infrastructure.GraphQL;

public class Query
{
    public async Task<List<CategoryDto>>
        AllCategories([Service] IMediator mediator, int page = 1, string? userId = null) =>
        await mediator.Send(new AllCategories() {UserId = userId, Page = page});

    public async Task<List<FlashCardDto>> RunFlashCards([Service] IMediator mediator, string userId,
        Frequency frequency) => await mediator.Send(new RunFlashCards() {UserId = userId, Frequency = frequency});
}
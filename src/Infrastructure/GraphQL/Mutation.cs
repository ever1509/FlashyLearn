using Application.Categories.Commands.CreateCategory;
using Application.Categories.Commands.DeleteCategory;
using Application.Categories.Dtos;
using Application.FlashCards.Commands.CreateFlashCard;
using Application.FlashCards.Commands.DeleteFlashCard;
using Application.FlashCards.Dtos;
using MediatR;

namespace Infrastructure.GraphQL;

public class Mutation
{
    public async Task<CategoryResponseDto> CreateCategory([Service] IMediator mediator, CreateCategoryCommand command) => await mediator.Send(command);

    public async Task<CategoryResponseDto> DeleteCategory([Service] IMediator mediator, DeleteCategoryCommand command) => await mediator.Send(command);
    
    public async Task<FlashCardResponseDto> CreateFlashCard([Service] IMediator mediator, CreateFlashCardCommand command) => await mediator.Send(command);
    
    public async Task<FlashCardResponseDto> DeleteFlashCard([Service] IMediator mediator, DeleteFlashCard command) => await mediator.Send(command);
    
}
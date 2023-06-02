using Application.Categories.Commands.CreateCategory;
using Application.Categories.Commands.DeleteCategory;
using Application.FlashCards.Commands.CreateFlashCard;
using Application.FlashCards.Commands.DeleteFlashCard;
using Application.FlashCards.Commands.UpdateFlashCard;
using MediatR;

namespace Infrastructure.GraphQL;

public class Mutation
{
    public async Task CreateCategory([Service] IMediator mediator, CreateCategoryCommand command) => await mediator.Send(command);

    public async Task DeleteCategory([Service] IMediator mediator, DeleteCategoryCommand command) => await mediator.Send(command);
    
    public async Task CreateFlashCard([Service] IMediator mediator, CreateFlashCardCommand command) => await mediator.Send(command);
    
    public async Task UpdateFlashCard([Service] IMediator mediator, UpdateFlashCard command) => await mediator.Send(command);
    
    public async Task DeleteFlashCard([Service] IMediator mediator, DeleteFlashCard command) => await mediator.Send(command);
    
}
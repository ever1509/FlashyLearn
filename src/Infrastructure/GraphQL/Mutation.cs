using Application.Categories.Commands.DeleteCategory;
using Application.Categories.Commands.SaveCategory;
using Application.Categories.Dtos;
using Application.FlashCards.Commands.DeleteFlashCard;
using Application.FlashCards.Commands.SaveFlashCard;
using Application.FlashCards.Dtos;
using Application.Tags.Commands.DeleteTag;
using Application.Tags.Commands.SaveTag;
using Application.Tags.Dtos;
using MediatR;

namespace Infrastructure.GraphQL;

public class Mutation
{
    public async Task<CategoryResponseDto> SaveCategory([Service] IMediator mediator, SaveCategoryCommand command) => await mediator.Send(command);

    public async Task<CategoryResponseDto> DeleteCategory([Service] IMediator mediator, DeleteCategoryCommand command) => await mediator.Send(command);
    
    public async Task<FlashCardResponseDto> SaveFlashCard([Service] IMediator mediator, SaveFlashCardCommand command) => await mediator.Send(command);
    
    public async Task<FlashCardResponseDto> DeleteFlashCard([Service] IMediator mediator, DeleteFlashCard command) => await mediator.Send(command);
    
    public async Task<TagResponseDto> SaveTag([Service] IMediator mediator, SaveTagCommand command) => await mediator.Send(command);
    
    public async Task<TagResponseDto> DeleteTag([Service] IMediator mediator, DeleteTagCommand command) => await mediator.Send(command);

}
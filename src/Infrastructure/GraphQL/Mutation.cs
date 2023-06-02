using Application.Categories.Commands.CreateCategory;
using Application.Categories.Dtos;
using MediatR;

namespace Infrastructure.GraphQL;

public class Mutation
{
    public async Task CreateOrUpdateCategory([Service] IMediator mediator, CategoryRequestDto categoryDto)
    {
        await mediator.Send(new CreateCategoryCommand() {Name = categoryDto.Name});
    }
}
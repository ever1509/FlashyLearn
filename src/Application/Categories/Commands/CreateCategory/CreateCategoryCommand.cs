using Application.Categories.Dtos;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Categories.Commands.CreateCategory;

public class CreateCategoryCommand : IRequest<CategoryResponseDto>
{
    public string? CategoryID { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string? UserID { get; set; } = string.Empty;
}

public class CreateCategoryCommandHandler: IRequestHandler<CreateCategoryCommand, CategoryResponseDto>
{
    private readonly ICategoryRepository _repository;

    public CreateCategoryCommandHandler(ICategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<CategoryResponseDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var userId = !string.IsNullOrEmpty(request.UserID) ? Guid.Parse(request.UserID) : Guid.Empty;
        
        if (string.IsNullOrEmpty(request.CategoryID))
        {
            var newCategory = new Category()
            {
                CategoryID = Guid.NewGuid(), 
                Name = request.Name, 
                UserID = userId
            };
        
            await _repository.Create(newCategory, cancellationToken);

            return new CategoryResponseDto()
            {
                CategoryID = newCategory.CategoryID,
                Name = newCategory.Name,
                UserID = newCategory.UserID
            };
        }

        if (!Guid.TryParse(request.CategoryID, out var categoryId)) throw new Exception("Invalid categoryId");
        
        await _repository.UpdateAsync(categoryId, request, cancellationToken);
        return new CategoryResponseDto()
        {
            CategoryID = categoryId,
            Name = request.Name,
            UserID = userId
        };
    }
}

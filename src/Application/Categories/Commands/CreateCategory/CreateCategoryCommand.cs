using Application.Categories.Dtos;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Categories.Commands.CreateCategory;

public class CreateCategoryCommand : IRequest<CategoryResponseDto>
{
    public string CategoryID { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string? UserId { get; set; } = string.Empty;
}

public class CreateCategoryCommandHandler: IRequestHandler<CreateCategoryCommand, CategoryResponseDto>
{
    private readonly ICategoryRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateCategoryCommandHandler(ICategoryRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<CategoryResponseDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        if (Guid.TryParse(request.UserId, out var userId))
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
                CategoryId = newCategory.CategoryID,
                Name = newCategory.Name
            };
        }

        throw new Exception("Invalid userId");
    }
}

using Application.Categories.Dtos;
using Application.Common.Interfaces;
using MediatR;

namespace Application.Categories.Commands.DeleteCategory;

public class DeleteCategoryCommand: IRequest<CategoryResponseDto>
{
    public string Id { get; set; } = string.Empty;
}

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, CategoryResponseDto>
{
    private readonly ICategoryRepository _repository;

    public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository)
    {
        _repository = categoryRepository;
    }

    public async Task<CategoryResponseDto> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var id = Guid.Parse(request.Id);
        var entity = await _repository.Get(x => x != null && x.CategoryID == id, cancellationToken: cancellationToken);
        if (entity is null)
            throw new Exception("Invalid category ID");

        await _repository.Delete(entity, cancellationToken);

        return new CategoryResponseDto()
        {
            CategoryID = entity.CategoryID,
            Name = entity.Name,
            UserID = entity.UserID
        };
    }
}
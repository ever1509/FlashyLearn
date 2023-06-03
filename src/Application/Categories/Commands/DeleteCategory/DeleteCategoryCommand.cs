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
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
    {
        _repository = categoryRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<CategoryResponseDto> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var id = Guid.Parse(request.Id);
        var entity = await _repository.Get(x => x != null && x.CategoryID == id, cancellationToken: cancellationToken);
        if (entity is null)
            throw new Exception("Invalid ID");

        _repository.Delete(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return new CategoryResponseDto()
        {
            CategoryId = entity.CategoryID,
            Name = entity.Name
        };
    }
}
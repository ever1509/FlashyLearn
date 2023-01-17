using Application.Common.Interfaces;
using MediatR;

namespace Application.Categories.Commands.DeleteCategory;

public class DeleteCategoryCommand: IRequest<Unit>
{
    public string Id { get; set; } = string.Empty;
}

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Unit>
{
    private readonly ICategoryRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
    {
        _repository = categoryRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var id = Guid.Parse(request.Id);
        var entity = await _repository.Get(x => x != null && x.Id == id, cancellationToken: cancellationToken);
        if (entity is null)
            throw new Exception("Invalid ID");

        await _repository.DeleteAsync(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}
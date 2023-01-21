using Application.Common.Interfaces;
using MediatR;

namespace Application.FlashCards.Commands.DeleteFlashCard;

public class DeleteFlashCard : IRequest<Unit>
{
    public string Id { get; set; } = string.Empty;
}

public class DeleteFlashCardHandler : IRequestHandler<DeleteFlashCard, Unit>
{
    private readonly IFlashCardRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteFlashCardHandler(IFlashCardRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(DeleteFlashCard request, CancellationToken cancellationToken)
    {
        var id = Guid.Parse(request.Id);
        
        var entity = await _repository.Get(x => x != null && x.Id == id, cancellationToken: cancellationToken);
        if (entity is null)
            throw new Exception("Invalid ID");

        _repository.Delete(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}
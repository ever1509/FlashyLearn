using Application.Common.Interfaces;
using Application.FlashCards.Dtos;
using MediatR;

namespace Application.FlashCards.Commands.DeleteFlashCard;

public class DeleteFlashCard : IRequest<FlashCardResponseDto>
{
    public string Id { get; set; } = string.Empty;
}

public class DeleteFlashCardHandler : IRequestHandler<DeleteFlashCard, FlashCardResponseDto>
{
    private readonly IFlashCardRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteFlashCardHandler(IFlashCardRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<FlashCardResponseDto> Handle(DeleteFlashCard request, CancellationToken cancellationToken)
    {
        var id = Guid.Parse(request.Id);
        
        var entity = await _repository.Get(x => x != null && x.FlashCardID == id, cancellationToken: cancellationToken);
        if (entity is null)
            throw new Exception("Invalid ID");

        _repository.Delete(entity, cancellationToken);

        return new FlashCardResponseDto()
        {
            FlashCardID = entity.FlashCardID,
            BackText = entity.BackText,
            FrontText = entity.FrontText,
            CategoryID = entity.CategoryID
        };
    }
}
using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Enums;
using MediatR;

namespace Application.FlashCards.Commands.CreateFlashCard;

public class CreateFlashCardCommand : IRequest<string>
{
    public string FrontText { get; set; } = string.Empty;
    public string BackText { get; set; } = string.Empty;
    public string CategoryID { get; set; } = string.Empty;
}

public class CreateFlashCardCommandHandler : IRequestHandler<CreateFlashCardCommand, string>
{
    private readonly IFlashCardRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateFlashCardCommandHandler(IFlashCardRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<string> Handle(CreateFlashCardCommand request, CancellationToken cancellationToken)
    {
        var newFlashCard = FlashCard.Create(Guid.NewGuid(), request.BackText, request.FrontText,
            DateTime.UtcNow, Frequency.Monthly, Guid.Parse(request.CategoryID));

        await _repository.CreateAsync(newFlashCard);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return newFlashCard.Id.ToString();

    }
}
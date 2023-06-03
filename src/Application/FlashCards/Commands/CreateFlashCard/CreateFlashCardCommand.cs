using Application.Common.Interfaces;
using Application.FlashCards.Dtos;
using Domain.Entities;
using Domain.Enums;
using MediatR;

namespace Application.FlashCards.Commands.CreateFlashCard;

public class CreateFlashCardCommand : IRequest<FlashCardResponseDto>
{
    public string FrontText { get; set; } = string.Empty;
    public string BackText { get; set; } = string.Empty;
    public string CategoryID { get; set; } = string.Empty;
}

public class CreateFlashCardCommandHandler : IRequestHandler<CreateFlashCardCommand, FlashCardResponseDto>
{
    private readonly IFlashCardRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateFlashCardCommandHandler(IFlashCardRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<FlashCardResponseDto> Handle(CreateFlashCardCommand request, CancellationToken cancellationToken)
    {
        var newFlashCard = FlashCard.Create(Guid.NewGuid(), request.FrontText, request.BackText,
            Frequency.Monthly, Guid.Parse(request.CategoryID));

        await _repository.CreateAsync(newFlashCard);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return new FlashCardResponseDto()
        {
            FlashCardId = newFlashCard.FlashCardID,
            BackText = newFlashCard.BackText,
            FrontText = newFlashCard.FrontText
        };

    }
}
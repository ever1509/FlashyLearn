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
        if (!Guid.TryParse(request.CategoryID, out var categoryId)) throw new Exception("Invalid category Id");
        
        var newFlashCard = new FlashCard()
        {
            FlashCardID = Guid.NewGuid(),
            FrontText = request.FrontText,
            BackText = request.BackText,
            Frequency = Frequency.Monthly,
            CategoryID = categoryId
        };
            
        await _repository.CreateAsync(newFlashCard, cancellationToken);

        return new FlashCardResponseDto()
        {
            FlashCardId = newFlashCard.FlashCardID,
            BackText = newFlashCard.BackText,
            FrontText = newFlashCard.FrontText
        };

    }
}
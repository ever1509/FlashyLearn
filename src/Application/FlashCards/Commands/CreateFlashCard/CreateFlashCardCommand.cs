using Application.Common.Interfaces;
using Application.FlashCards.Dtos;
using Domain.Entities;
using Domain.Enums;
using MediatR;

namespace Application.FlashCards.Commands.CreateFlashCard;

public class CreateFlashCardCommand : IRequest<FlashCardResponseDto>
{
    public string? FlashcarID { get; set; } = string.Empty;
    public Frequency Frequency { get; set; }
    public string FrontText { get; set; } = string.Empty;
    public string BackText { get; set; } = string.Empty;
    public string CategoryID { get; set; } = string.Empty;
}

public class CreateFlashCardCommandHandler : IRequestHandler<CreateFlashCardCommand, FlashCardResponseDto>
{
    private readonly IFlashCardRepository _repository;

    public CreateFlashCardCommandHandler(IFlashCardRepository repository)
    {
        _repository = repository;
    }

    public async Task<FlashCardResponseDto> Handle(CreateFlashCardCommand request, CancellationToken cancellationToken)
    {
        if (!Guid.TryParse(request.CategoryID, out var categoryId)) throw new Exception("Invalid category Id");

        if (string.IsNullOrEmpty(request.FlashcarID))
        {
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
                FlashCardID = newFlashCard.FlashCardID,
                BackText = newFlashCard.BackText,
                FrontText = newFlashCard.FrontText,
                CategoryID = newFlashCard.CategoryID
            };   
        }
        
        if (!Guid.TryParse(request.FlashcarID, out var flashCardId)) throw new Exception("Invalid flashCardId");

        await _repository.UpdateAsync(flashCardId, request, cancellationToken);
        return new FlashCardResponseDto()
        {
            FlashCardID = flashCardId,
            BackText = request.BackText,
            FrontText = request.FrontText,
            CategoryID = categoryId
        };   
        
        
    }
}
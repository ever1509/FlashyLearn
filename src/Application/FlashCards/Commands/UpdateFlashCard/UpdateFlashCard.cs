using Application.Common.Interfaces;
using Application.FlashCards.Dtos;
using Domain.Enums;
using MediatR;

namespace Application.FlashCards.Commands.UpdateFlashCard;

public class UpdateFlashCard : IRequest<FlashCardResponseDto>
{
    public string Id { get; set; } = string.Empty;
    public string FrontText { get; set; } = string.Empty;
    public string BackText { get; set; } = string.Empty;
    public string CategoryId { get; set; } = string.Empty;
    public Frequency Frequency { get; set; }
}

public class UpdateFlashCardHandler : IRequestHandler<UpdateFlashCard, FlashCardResponseDto>
{
    private readonly IFlashCardRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateFlashCardHandler(IFlashCardRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<FlashCardResponseDto> Handle(UpdateFlashCard request, CancellationToken cancellationToken)
    {
        var entity = await _repository.Get(x => x != null && x.FlashCardID == Guid.Parse( request.Id), cancellationToken: cancellationToken);
        
        if (entity is null)
            throw new Exception("Invalid ID");

        entity.Update(request.FrontText, request.BackText, request.Frequency, Guid.Parse(request.CategoryId));
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return new FlashCardResponseDto()
        {
            FlashCardId = entity.FlashCardID,
            FrontText = entity.FrontText,
            BackText = entity.BackText
        };
    }
}
using Application.Common.Interfaces;
using Domain.Enums;
using MediatR;

namespace Application.FlashCards.Commands.UpdateFlashCard;

public class UpdateFlashCard : IRequest<string>
{
    public string Id { get; set; } = string.Empty;
    public string FrontText { get; set; } = string.Empty;
    public string BackText { get; set; } = string.Empty;
    public string CategoryId { get; set; } = string.Empty;
    public Frequency Frequency { get; set; }
}

public class UpdateFlashCardHandler : IRequestHandler<UpdateFlashCard, string>
{
    private readonly IFlashCardRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateFlashCardHandler(IFlashCardRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<string> Handle(UpdateFlashCard request, CancellationToken cancellationToken)
    {
        var entity = await _repository.Get(x => x != null && x.Id == Guid.Parse( request.Id), cancellationToken: cancellationToken);
        
        if (entity is null)
            throw new Exception("Invalid ID");

        entity.Update(request.FrontText, request.BackText, Guid.Parse(request.CategoryId), request.Frequency);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return entity.Id.ToString();
    }
}
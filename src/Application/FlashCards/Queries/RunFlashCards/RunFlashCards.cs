using Application.Common.Interfaces;
using Application.FlashCards.Dtos;
using Domain.Enums;
using MediatR;

namespace Application.FlashCards.Queries.RunFlashCards;

public class RunFlashCards : IRequest<List<FlashCardDto>>
{
    //public string? UserId { get; set; }
}

public class RunFlashCardsHandler : IRequestHandler<RunFlashCards, List<FlashCardDto>>
{
    private readonly IFlashCardRepository _repository;

    public RunFlashCardsHandler(IFlashCardRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<FlashCardDto>> Handle(RunFlashCards request, CancellationToken cancellationToken)
    {
        return await _repository.RunFlashCards(request, cancellationToken);
    }
}
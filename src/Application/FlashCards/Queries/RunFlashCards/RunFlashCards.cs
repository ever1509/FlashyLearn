using Application.Common.Interfaces;
using Application.FlashCards.Dtos;
using Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.FlashCards.Queries.RunFlashCards;

public class RunFlashCards : IRequest<List<FlashCardDto>>
{
    public string UserId { get; set; }
    public Frequency Frequency { get; set; }
}

public class RunFlashCardsHandler : IRequestHandler<RunFlashCards, List<FlashCardDto>>
{
    private readonly IFlashyLearnContext _context;

    public RunFlashCardsHandler(IFlashyLearnContext context)
    {
        _context = context;
    }

    public async Task<List<FlashCardDto>> Handle(RunFlashCards request, CancellationToken cancellationToken)
    {
        var flashCardsDto = new List<FlashCardDto>();

        var flashCards = await _context.FlashCards.Where(x=>x.Frequency == request.Frequency).ToListAsync(cancellationToken);


        foreach (var flashCard in flashCards)
        {
            flashCardsDto.Add(new FlashCardDto
            {
                FrontText = flashCard.FrontText,
                BackText = flashCard.BackText,
                CategoryId = flashCard.CategoryID.ToString()
            });
        }
        
        return flashCardsDto;
    }
}
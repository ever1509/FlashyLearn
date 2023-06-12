using Application.FlashCards.Queries.RunFlashCards;
using Grpc.Core;
using MediatR;

namespace FlashyLearn.API.gRPC.Services;

public class FlashCardService : FlashCards.FlashCardsBase
{
    private readonly IMediator _mediator;

    public FlashCardService(IMediator mediator)
    {
        _mediator = mediator;
    }

    public override async Task<RunFlashCardsResponse> RunFlashCards(RunFlashCardsRequest request, ServerCallContext context)
    {
        var flashCards = await _mediator.Send(new RunFlashCards());

        var response = new RunFlashCardsResponse();
        foreach (var flashCardDto in flashCards)
        {
            response.FlashCards.Add(new FlashCardResponse
            {
                FlashCardId = flashCardDto.FlashCardID.ToString(),
                CategoryId = flashCardDto.CategoryID.ToString(),
                Frequency = (int)flashCardDto.Frequency,
                BackText = flashCardDto.BackText,
                FrontText = flashCardDto.FrontText
            });
        }

        return response;
    }
}